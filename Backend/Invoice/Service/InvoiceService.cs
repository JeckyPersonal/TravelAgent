
using Invoice.Repository;

namespace Invoice.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository<Model.Invoice> _invoiceRepository;
        private readonly AssertService<Model.Invoice> _assertService;

        public InvoiceService(IInvoiceRepository<Model.Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _assertService = new AssertService<Model.Invoice>(invoiceRepository);
        }

        public async Task<Model.Invoice> Add(Model.Invoice entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(Model.Invoice));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<Model.Invoice> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(Model.Invoice));

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true, new List<string>() { "Customer", "BankDetail", "BankDetail.Bank" });
        }

        public async Task<List<Model.Invoice>> GetAll()
        {
            return await this._invoiceRepository.GetAll(new List<string>() { "Customer", "BankDetail", "BankDetail.Bank" });
        }

        public async Task<Model.Invoice> GetInvoiceForPrint(int invoiceId)
        {
            return await this._invoiceRepository.Get(x => x.Id.Equals(invoiceId), true, new List<string>() { "FinancialYear.Company", "Customer", "InvoiceDetail", "InvoiceDetail.Item", "InvoiceDetail.VoucherDetail.Voucher.Vehicle", "BankDetail.Bank", "Vouchers" });
        }

        public string GetInvoiceNo()
        {
            int totalInvoicePerMonth = this._invoiceRepository.GetMultiple(x => x.InvoiceDate.Month.Equals(DateTime.Now.Month), true).Result.Count;

            totalInvoicePerMonth = totalInvoicePerMonth == 0 ? 1 : totalInvoicePerMonth;
            string invoiceIndex = string.Empty;
            if (totalInvoicePerMonth < 10)
            {
                invoiceIndex = $"00{totalInvoicePerMonth}";
            }
            else if (totalInvoicePerMonth < 100)
            {
                invoiceIndex = $"0{totalInvoicePerMonth}";
            }
            else
            {
                invoiceIndex = totalInvoicePerMonth.ToString();
            }

            string currentTime = $"{DateTime.Now.ToString("dd-MMM-yyyy")}-{invoiceIndex}";

            return currentTime;
        }

        public async Task<Model.Invoice> Update(Model.Invoice entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(Model.Invoice));

            Model.Invoice invoiceById = await this._assertService.AssertEntityExist(x=> x.Id.Equals(entity.Id), nameof(Model.Invoice));

            invoiceById.InvoiceDate = entity.InvoiceDate;
            invoiceById.InvoiceNo = entity.InvoiceNo;
            invoiceById.CGST = entity.CGST;
            invoiceById.SGST = entity.SGST;
            invoiceById.IGST = entity.IGST;
            invoiceById.Total = entity.Total;

            return await this._invoiceRepository.Update(invoiceById);
        }
    }
}
