using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Repository;
using Microsoft.OpenApi.Writers;

namespace Invoice.Service
{
    public class FinancialYearService : IFinancialYearService
    {
        private readonly IInvoiceRepository<FinancialYear> _invoiceRepository;
        private readonly AssertService<FinancialYear> _assertService;

        public FinancialYearService(IInvoiceRepository<FinancialYear> invoiceRepository)
        {
            this._invoiceRepository = invoiceRepository;
            this._assertService = new AssertService<FinancialYear>(invoiceRepository);
        }

        public async Task<FinancialYear> Add(FinancialYear entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(FinancialYear));

            this._assertService.AssertDuplicationEntity(x => x.FromDate == entity.FromDate && x.ToDate == entity.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            this._assertService.AssertDuplicationEntity(x => entity.FromDate >= x.FromDate && entity.FromDate <= x.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            this._assertService.AssertDuplicationEntity(x => entity.ToDate >= x.FromDate && entity.ToDate <= x.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<FinancialYear> Delete(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(FinancialYear));

            FinancialYear yearWithReference = await this._invoiceRepository.Get(
                x => x.Id.Equals(id),
                true,
                y => y.Invoices.Take(1),
                y => y.Vouchers.Take(1),
                y => y.Payments.Take(1));

            if(yearWithReference.Invoices.Any() ||  yearWithReference.Vouchers.Any() || yearWithReference.Payments.Any())
                throw new DeleteConflictException("This financial year cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the financial year.");

            FinancialYear financialYearById = await this.Get(id);

            return await this._invoiceRepository.Delete(financialYearById);
        }

        public async Task<FinancialYear> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(FinancialYear));

            return await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(FinancialYear));
        }

        public async Task<List<FinancialYear>> GetAll()
        {
            return await this._invoiceRepository.GetAll();
        }

        public async Task<FinancialYear> GetFinancialYearWithSingleRelatedEntity(int financialYearId)
        {
            this._assertService.AssertNonZeroId(financialYearId, nameof(FinancialYear));

            return await this._invoiceRepository.Get(
                x => x.Id.Equals(financialYearId),
                true,
                y => y.Invoices.FirstOrDefault(),
                y => y.Vouchers.FirstOrDefault(),
                y => y.Payments.FirstOrDefault());
        }


        public async Task<FinancialYear> Update(FinancialYear entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(FinancialYear));

            this._assertService.AssertDuplicationEntity(x => x.FromDate == entity.FromDate && x.ToDate == entity.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            this._assertService.AssertDuplicationEntity(x => entity.FromDate >= x.FromDate && entity.FromDate <= x.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            this._assertService.AssertDuplicationEntity(x => entity.ToDate >= x.FromDate && entity.ToDate <= x.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            FinancialYear yearById = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(FinancialYear));

            yearById.FromDate = entity.FromDate;
            yearById.ToDate = entity.ToDate;

            return await this._invoiceRepository.Update(yearById);
        }
    }
}
