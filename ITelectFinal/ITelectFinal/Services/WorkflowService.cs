using ITelectFinal.Data;
using ITelectFinal.Repositories;
using ITelectFinal.Utils;
using Microsoft.EntityFrameworkCore;

namespace ITelectFinal.Services
{
    public class WorkflowService
    {
        private readonly WorkflowTaskRepository _repository;

        public WorkflowService(WorkflowTaskRepository repository)
        {
            _repository = repository;
        }

        public WorkflowService()
            : this(new WorkflowTaskRepository())
        {
        }

        // O(n) update: Pending -> InProgress
        public async Task UpdateWorkflowStatusAsync()
        {
            try
            {
                await using var context = new AppDbContext();
                var orderStatusById = await context.Orders
                    .ToDictionaryAsync(o => o.OrderId, o => o.OrderStatus);

                var tasks = await _repository.GetAllAsync();

                foreach (var task in tasks)
                {
                    if (!orderStatusById.TryGetValue(task.OrderId, out var orderStatus))
                        continue;

                    bool isPaid = string.Equals(orderStatus, "Completed", StringComparison.OrdinalIgnoreCase);

                    if (string.Equals(task.Status, "Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        if (isPaid)
                        {
                            task.Status = "InProgress";
                            task.LastUpdated = DateTime.Now;
                            task.TaskDescription = "Payment received. Production started.";
                            await _repository.UpdateAsync(task);
                        }
                        else
                        {
                            // Keep it as "Not paid yet" until payment is recorded.
                            if (!string.Equals(task.TaskDescription, "Not paid yet", StringComparison.OrdinalIgnoreCase))
                            {
                                task.TaskDescription = "Not paid yet";
                                task.LastUpdated = DateTime.Now;
                                await _repository.UpdateAsync(task);
                            }
                        }
                    }
                    else if (string.Equals(task.Status, "InProgress", StringComparison.OrdinalIgnoreCase))
                    {
                        // Only complete if order is paid.
                        if (isPaid)
                        {
                            task.Status = "Completed";
                            task.LastUpdated = DateTime.Now;
                            task.TaskDescription = "Completed.";
                            await _repository.UpdateAsync(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }

        // Update only tasks for a single order (faster for POS payment events).
        public async Task UpdateWorkflowStatusForOrderAsync(int orderId)
        {
            if (orderId <= 0)
                return;

            try
            {
                await using var context = new AppDbContext();
                var orderStatus = await context.Orders
                    .Where(o => o.OrderId == orderId)
                    .Select(o => o.OrderStatus)
                    .FirstOrDefaultAsync();

                if (string.IsNullOrWhiteSpace(orderStatus))
                    return;

                bool isPaid = string.Equals(orderStatus, "Completed", StringComparison.OrdinalIgnoreCase);

                var tasks = _repository.GetByOrderId(orderId);

                foreach (var task in tasks)
                {
                    if (string.Equals(task.Status, "Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        if (isPaid)
                        {
                            task.Status = "InProgress";
                            task.LastUpdated = DateTime.Now;
                            task.TaskDescription = "Payment received. Production started.";
                            await _repository.UpdateAsync(task);
                        }
                        else
                        {
                            task.TaskDescription = "Not paid yet";
                            task.LastUpdated = DateTime.Now;
                            await _repository.UpdateAsync(task);
                        }
                    }
                    else if (string.Equals(task.Status, "InProgress", StringComparison.OrdinalIgnoreCase))
                    {
                        if (isPaid)
                        {
                            task.Status = "Completed";
                            task.LastUpdated = DateTime.Now;
                            task.TaskDescription = "Completed.";
                            await _repository.UpdateAsync(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }
    }
}

