namespace PensionGrantTracker.Models
{
    public class Beneficiary
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string Phone { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public string GrantType { get; set; }
        public decimal MonthlyAmount { get; set; }
        public string Status { get; set; }
        public int PayPointId { get; set; }
        public string PayPointName { get; set; }
    }
}
