namespace Invoice.Model
{
    public class BankDetail
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string? IFSCCode { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public List<Model.Invoice> Invoices { get; set; }
    }
}
