using ITelectFinal.Models;
using ITelectFinal.Repositories;
using ITelectFinal.Utils;

namespace ITelectFinal.Services
{
    public class PaymentService
    {
        private readonly PaymentRepository _repo;
        private readonly OrderRepository _orderRepo;

        public PaymentService(PaymentRepository repo)
        {
            _repo = repo;
            _orderRepo = new OrderRepository();
        }

        public PaymentService()
            : this(new PaymentRepository())
        {
            _orderRepo = new OrderRepository();
        }

        public PaymentService(PaymentRepository repo, OrderRepository orderRepo)
        {
            _repo = repo;
            _orderRepo = orderRepo;
        }

        public async Task ProcessNewPaymentAsync(int orderId, decimal amountPaid, string paymentMethod, int processedByUserId)
        {
            if (orderId <= 0)
                throw new Exception("OrderId is required.");

            if (amountPaid <= 0)
                throw new Exception("AmountPaid must be greater than 0.");

            if (processedByUserId <= 0)
                throw new Exception("ProcessedByUserId is required.");

            if (string.IsNullOrWhiteSpace(paymentMethod))
                paymentMethod = "Cash";

            var order = _orderRepo.GetById(orderId);
            if (order == null)
                throw new Exception("Order not found.");

            // simple validation: payment should cover total
            if (amountPaid < order.TotalAmount)
                throw new Exception("AmountPaid must be greater than or equal to TotalAmount.");

            var payment = new Payment
            {
                OrderId = orderId,
                AmountPaid = amountPaid,
                PaymentMethod = paymentMethod.Trim(),
                PaymentDate = DateTime.Now,
                ProcessedByUserId = processedByUserId
            };

            await _repo.CreateAsync(payment);

            // After payment, update order status to align with the ERD/DFD behavior.
            var updatedOrder = _orderRepo.GetById(orderId);
            if (updatedOrder != null)
            {
                updatedOrder.OrderStatus = amountPaid >= updatedOrder.TotalAmount ? "Completed" : "Processing";
                _orderRepo.Update(updatedOrder);
            }

            // Immediately advance workflow tasks for this order (so no "Workflow" click is needed).
            await new WorkflowService().UpdateWorkflowStatusForOrderAsync(orderId);
        }

        public async Task ProcessNewPaymentForCurrentUserAsync(int orderId, decimal amountPaid, string paymentMethod)
        {
            var userId = Session.CurrentUser?.UserId ?? 0;
            if (userId <= 0)
                throw new Exception("No user is logged in.");
            await ProcessNewPaymentAsync(orderId, amountPaid, paymentMethod, userId);
        }
    }
}

