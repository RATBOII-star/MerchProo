using ITelectFinal.Data;
using ITelectFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ITelectFinal.Repositories
{
    public class WorkflowTaskRepository
    {
        private readonly AppDbContext _context;

        public WorkflowTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public WorkflowTaskRepository()
            : this(new AppDbContext())
        {
        }

        public async Task AddAsync(WorkflowTask task)
        {
            await _context.WorkflowTasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<WorkflowTask>> GetAllAsync()
        {
            return await _context.WorkflowTasks.ToListAsync();
        }

        public async Task<WorkflowTask?> GetByIdAsync(int id)
        {
            return await _context.WorkflowTasks.FindAsync(id);
        }

        public async Task UpdateAsync(WorkflowTask task)
        {
            _context.WorkflowTasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.WorkflowTasks.FindAsync(id);
            if (task != null)
            {
                _context.WorkflowTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public bool ExistsForOrder(int orderId)
        {
            return _context.WorkflowTasks.Any(t => t.OrderId == orderId);
        }

        public List<WorkflowTask> GetByOrderId(int orderId)
        {
            return _context.WorkflowTasks
                .Where(t => t.OrderId == orderId)
                .ToList();
        }

        public void Add(WorkflowTask task)
        {
            _context.WorkflowTasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(WorkflowTask task)
        {
            _context.WorkflowTasks.Update(task);
            _context.SaveChanges();
        }
    }
}

