using Invoice.Model;

namespace Invoice
{
    public class AppContext : IAppContext
    {

        public int CompanyId { get; set; }
        public int AccYearId { get; set; }

        public Company GetCompany()
        {
            throw new NotImplementedException();
        }
    }
}
