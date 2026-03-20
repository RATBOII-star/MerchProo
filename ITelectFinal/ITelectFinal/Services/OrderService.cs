using ITelectFinal.Models;
using ITelectFinal.Repositories;
using ITelectFinal.Utils;

namespace ITelectFinal.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;
        private readonly WorkflowTaskRepository _workflowTaskRepository;

        private static readonly HashSet<string> AllowedStatuses =
            new(StringComparer.OrdinalIgnoreCase) { "Pending", "Processing", "Completed", "Cancelled" };

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = new CustomerRepository();
            _productRepository = new ProductRepository();
            _workflowTaskRepository = new WorkflowTaskRepository();
        }

        public OrderService(OrderRepository orderRepository, CustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = new ProductRepository();
            _workflowTaskRepository = new WorkflowTaskRepository();
        }

        public Order CreateOrder(int customerId, int createdByUserId, List<(int productId, int quantity, decimal? unitPrice)> items)
        {
            if (customerId <= 0)
                throw new Exception("CustomerId is required.");

            if (createdByUserId <= 0)
                throw new Exception("CreatedByUserId is required.");

            if (items == null || items.Count == 0)
                throw new Exception("At least one order item is required.");

            var customer = _customerRepository.GetById(customerId);
            if (customer == null)
                throw new Exception("Customer not found.");

            var order = new Order
            {
                CustomerId = customerId,
                CreatedByUserId = createdByUserId,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending"
            };

            decimal total = 0m;
            foreach (var item in items)
            {
                if (item.quantity <= 0)
                    throw new Exception("Item quantity must be greater than 0.");

                var product = _productRepository.GetById(item.productId);
                if (product == null)
                    throw new Exception("Product not found.");

                var price = item.unitPrice ?? product.BasePrice;
                if (price < 0)
                    throw new Exception("Unit price cannot be negative.");

                order.Items.Add(new OrderItem
                {
                    ProductId = product.ProductId,
                    Quantity = item.quantity,
                    UnitPrice = price
                });

                total += price * item.quantity;
            }

            order.TotalAmount = total;
            _orderRepository.Add(order);

            // Create an initial workflow task for this order (Pending until paid).
            if (!_workflowTaskRepository.ExistsForOrder(order.OrderId))
            {
                _workflowTaskRepository.Add(new WorkflowTask
                {
                    OrderId = order.OrderId,
                    TaskName = "Order Processing",
                    TaskDescription = "Not paid yet",
                    AssignedRole = "Prod. Staff",
                    Status = "Pending",
                    LastUpdated = DateTime.Now
                });
            }
            return order;
        }

        public void UpdateOrderStatus(Order order, string status)
        {
            if (order == null)
                throw new Exception("Order is required.");

            var normalized = NormalizeStatus(status);

            if (!AllowedStatuses.Contains(normalized))
                throw new Exception("Invalid status. Allowed: Pending, Processing, Completed, Cancelled.");

            if (string.Equals(order.OrderStatus, "Completed", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(order.OrderStatus, "Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Cannot update a completed/cancelled order.");
            }

            order.OrderStatus = normalized;
            _orderRepository.Update(order);
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            if (orderId <= 0)
                throw new Exception("OrderId is required.");

            var order = _orderRepository.GetById(orderId);
            if (order == null)
                throw new Exception("Order not found.");

            UpdateOrderStatus(order, status);
        }

        private static string NormalizeStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new Exception("Status is required.");

            return status.Trim();
        }

        public int GetCurrentUserIdOrThrow()
        {
            var userId = Session.CurrentUser?.UserId ?? 0;
            if (userId <= 0)
                throw new Exception("No user is logged in.");
            return userId;
        }
    }
}

