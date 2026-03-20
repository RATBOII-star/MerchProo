namespace ITelectFinal.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; } = "Cash";
        public DateTime PaymentDate { get; set; }

        public int ProcessedByUserId { get; set; }
        public User? ProcessedByUser { get; set; }
    }
}

