using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class ItemMasterService : IItemMasterService
    {
        private readonly IInvoiceRepository<ItemMaster> _invoiceRepository;
        private readonly IInvoiceRepository<ItemInterval> _intervalRepository;
        private readonly AssertService<ItemMaster> _assertService;

        public ItemMasterService(IInvoiceRepository<ItemMaster> invoiceRepository, IInvoiceRepository<ItemInterval> intervalRepository)
        {
            _invoiceRepository = invoiceRepository;
            _intervalRepository = intervalRepository;
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

            return await this._assertService.AssertEntityExist(x=> x.Id.Equals(id), nameof(ItemMaster));
        }

        public async Task<ItemMaster> GetWithInterval(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(ItemMaster));

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true, "Interval");
        }

        public async Task<List<ItemMaster>> GetAll()
        {
            return await this._invoiceRepository.GetAll(new List<string>() { "Interval" });
        }

        public async Task<List<ItemInterval>> GetAllIntervals()
        {
            return await this._intervalRepository.GetAll();
        }

        public async Task<ItemMaster> Update(ItemMaster entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(Bank));

            this._assertService.AssertDuplicationEntity(x => x.ItemName.Equals(entity.ItemName), x => x.Id != entity.Id, entity.ItemName);

            ItemMaster existingItem = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(ItemMaster));

            existingItem.AppliedGST = entity.AppliedGST;
            existingItem.ItemName = entity.ItemName;
            existingItem.Rate = entity.Rate;
            existingItem.Unit = entity.Unit;
            existingItem.Quantity = entity.Quantity;
            existingItem.IntervalId = entity.IntervalId;
            existingItem.ItemDescription = entity.ItemDescription;
            existingItem.ItemCategory = entity.ItemCategory;
            existingItem.ItemSource = entity.ItemSource;
            
            return await this._invoiceRepository.Update(existingItem);
        }

        public async Task<ItemMaster> Delete(int id)
        {
            ItemMaster itemWithReference = await this._invoiceRepository.Get(x => x.Id.Equals(id), true, i => i.InvoiceDetails.Take(1), i => i.VoucherDetails.Take(1), i => i.VehicleRates.Take(1));
            if(itemWithReference.InvoiceDetails.Any() || itemWithReference.VoucherDetails.Any() || itemWithReference.VehicleRates.Any())
                throw new DeleteConflictException("This item cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the item.");

            itemWithReference.InvoiceDetails = null;
            itemWithReference.VoucherDetails = null;
            itemWithReference.VehicleRates = null;

            return await this._invoiceRepository.Delete(itemWithReference);
        }
    }
}
