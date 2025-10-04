using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class FinancialYearService : IService<FinancialYear>
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

            await this._assertService.AssertDuplicationEntity(x => x.FromDate == entity.FromDate && x.ToDate == entity.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            await this._assertService.AssertDuplicationEntity(x => entity.FromDate >= x.FromDate && entity.FromDate <= x.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            await this._assertService.AssertDuplicationEntity(x => entity.ToDate >= x.FromDate && entity.ToDate <= x.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<FinancialYear> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(FinancialYear));

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true);
        }

        public async Task<List<FinancialYear>> GetAll()
        {
            return await this._invoiceRepository.GetAll();
        }

        public async Task<FinancialYear> Update(FinancialYear entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(FinancialYear));

            await this._assertService.AssertDuplicationEntity(x => x.FromDate == entity.FromDate && x.ToDate == entity.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            await this._assertService.AssertDuplicationEntity(x => entity.FromDate >= x.FromDate && entity.FromDate <= x.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            await this._assertService.AssertDuplicationEntity(x => entity.ToDate >= x.FromDate && entity.ToDate <= x.ToDate, x => !x.Id.Equals(entity.Id), nameof(FinancialYear));

            FinancialYear yearById = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(FinancialYear));

            yearById.FromDate = entity.FromDate;
            yearById.ToDate = entity.ToDate;

            return await this._invoiceRepository.Update(yearById);
        }
    }
}
