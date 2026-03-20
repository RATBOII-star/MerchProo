using System.ComponentModel.DataAnnotations;

namespace ITelectFinal.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        public string? Category { get; set; }

        public decimal BasePrice { get; set; }

        public string? Material { get; set; }
    }
}

