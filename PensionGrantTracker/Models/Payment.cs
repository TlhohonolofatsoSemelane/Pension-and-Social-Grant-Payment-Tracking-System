namespace PensionGrantTracker.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BeneficiaryId { get; set; }
        public string BeneficiaryName { get; set; }
        public string PayPointName { get; set; }
        public string PaymentMonth { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string PaidDate { get; set; }
        public string DelayReason { get; set; }
    }
}
