namespace Invoice
{
    public interface IAppContext
    {
        int CompanyId { get; set; }

        int AccYearId { get; set; }
    }
}
