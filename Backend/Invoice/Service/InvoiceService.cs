
using Invoice.Model;
using Invoice.Repository;
using System.Threading.Tasks;

namespace Invoice.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository<Model.Invoice> _invoiceRepository;
        private readonly AssertService<Model.Invoice> _assertService;
        private readonly IPaymentService _paymentService;

        public InvoiceService(IInvoiceRepository<Model.Invoice> invoiceRepository, IPaymentService paymentService)
        {
            _invoiceRepository = invoiceRepository;
            _assertService = new AssertService<Model.Invoice>(invoiceRepository);
            _paymentService = paymentService;
        }

        public async Task<Model.Invoice> Add(Model.Invoice entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(Model.Invoice));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<Model.Invoice> Delete(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(Model.Invoice));

            Model.Invoice invoiceById = await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(Model.Invoice));

            return await this._invoiceRepository.Delete(invoiceById);
        }

        public async Task<List<Model.Invoice>> DeleteAll(List<int> invoiceIds)
        {
            if (invoiceIds == null || invoiceIds.Count == 0) return new List<Model.Invoice>();

            List<Model.Invoice> invoiceByIds = await this._invoiceRepository.GetMultiple(x=> invoiceIds.Contains(x.Id), true);

            return await this._invoiceRepository.DeleteAll(invoiceByIds);
        }

        public async Task<Model.Invoice> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(Model.Invoice));

            Model.Invoice invoiceById = await this._assertService.AssertEntityExist(x=> x.Id.Equals(id), nameof(Model.Invoice));

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true, new List<string>() { "Customer", "BankDetail", "BankDetail.Bank" });
        }

        public async Task<List<Model.Invoice>> GetAll()
        {
            return await this._invoiceRepository.GetAll(new List<string>() { "Customer", "BankDetail", "BankDetail.Bank" });
        }

        public async Task<List<Model.Invoice>> GetAllInvoice(List<int> invoiceId)
        {
            List<Model.Invoice> invoices = new List<Model.Invoice>();

            if (invoiceId.Count == 0) return invoices;

            invoices = await this._invoiceRepository.GetMultiple(x => invoiceId.Contains(x.Id), true);

            return invoices;
        }

        public async Task<List<Model.Invoice>> GetAllPendingInvoiceOfCustomer(int customerId)
        {
            this._assertService.AssertNonZeroId(customerId, nameof(Customer));

            double totalReceivedPayment = 0.00; //this._paymentService.GetTotalPaymentOfInvoice();

            return await this._invoiceRepository.GetMultiple(x => x.CustomerId.Equals(customerId) && x.Total > totalReceivedPayment, true);
        }

        public async Task<Model.Invoice> GetByBankId(List<int> accountId)
        {
            //this._assertService.AssertNonZeroId(accountId, nameof(Model.Invoice));

            return await this._invoiceRepository.Get(x => accountId.Contains(x.BankDetailId),true);
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

        public async Task<Model.Invoice> GetInvoiceOfVoucher(int voucherId)
        {
            this._assertService.AssertNonZeroId(voucherId, nameof(VoucherMaster));

            return await this._invoiceRepository.Get(x=> x.Vouchers.Exists(x=> x.Id.Equals(voucherId)), true);
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

        public async Task<Model.Invoice> UpdateStatus(int id, VoucherStatus status)
        {
            this._assertService.AssertNonZeroId(id, nameof(Invoice.Model.Invoice));

            Model.Invoice invoiceById = await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(Model.Invoice));

            invoiceById.Status = status;

            return await this._invoiceRepository.Update(invoiceById);
        }
    }
}
