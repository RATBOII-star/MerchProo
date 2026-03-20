using System.ComponentModel.DataAnnotations;

namespace ITelectFinal.Models
{
    public class WorkflowTask
    {
        [Key]
        public int TaskId { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public string TaskName { get; set; } = string.Empty;
        public string TaskDescription { get; set; } = string.Empty;
        public string AssignedRole { get; set; } = "Prod. Staff";
        public string Status { get; set; } = "Pending"; // Pending, InProgress, Completed
        public DateTime LastUpdated { get; set; }
    }
}

