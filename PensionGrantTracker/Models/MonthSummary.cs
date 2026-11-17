namespace PensionGrantTracker.Models
{
    public class MonthSummary
    {
        public int Total { get; set; }
        public int Paid { get; set; }
        public int Pending { get; set; }
        public int Delayed { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountToPay { get; set; }
    }
}
