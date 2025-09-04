namespace Invoice.Model
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<BankDetail> BankDetail { get; set; }
    }
}
