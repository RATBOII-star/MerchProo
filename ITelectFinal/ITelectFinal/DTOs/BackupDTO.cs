using ITelectFinal.Models;

namespace ITelectFinal.DTOs
{
    public class BackupDTO
    {
        public List<User> Users { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
        public List<Product> Products { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
        public List<OrderItem> OrderItems { get; set; } = new();
        public List<Payment> Payments { get; set; } = new();
        public List<WorkflowTask> WorkflowTasks { get; set; } = new();
    }
}

