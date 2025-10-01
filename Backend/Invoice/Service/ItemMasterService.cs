using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class ItemMasterService : IService<ItemMaster>
    {
        private readonly IInvoiceRepository<ItemMaster> _invoiceRepository;
        private readonly AssertService<ItemMaster> _assertService;

        public ItemMasterService(IInvoiceRepository<ItemMaster> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            this._assertService = new AssertService<ItemMaster>(this._invoiceRepository);
        }

        public async Task<ItemMaster> Add(ItemMaster entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(ItemMaster));

            this._assertService.AssertDuplicationEntity(x => x.ItemName.Equals(entity.ItemName), x => x.Id != entity.Id, entity.ItemName);

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<ItemMaster> Get(int id)
        {
            this._assertService.AssertNonZeroId(id,nameof(ItemMaster));

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true);
        }

        public async Task<List<ItemMaster>> GetAll()
        {
            return await this._invoiceRepository.GetAll();
        }

        public async Task<ItemMaster> Update(ItemMaster entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(Bank));

            this._assertService.AssertDuplicationEntity(x => x.ItemName.Equals(entity.ItemName), x => x.Id != entity.Id, entity.ItemName);

            ItemMaster existingItem = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(ItemMaster));

            existingItem.AppliedGST = entity.AppliedGST;
            existingItem.ItemName = entity.ItemName;
            existingItem.Rate = entity.Rate;
            
            return await this._invoiceRepository.Update(existingItem);
        }
    }
}
