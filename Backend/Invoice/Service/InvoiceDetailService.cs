using Invoice.DTO;
using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceRepository<InvoiceDetail> _invoiceRepository;
        private readonly IInvoiceRepository<TenderMaster> _tenderRepository;
        private readonly IInvoiceRepository<ItemMaster> _itemRepository;
        private readonly AssertService<InvoiceDetail> _assertService;

        public InvoiceDetailService(IInvoiceRepository<InvoiceDetail> invoiceRepository, IInvoiceRepository<TenderMaster> tenderRepository, IInvoiceRepository<ItemMaster> itemRepository)
        {
            _invoiceRepository = invoiceRepository;
            _tenderRepository = tenderRepository;
            _itemRepository = itemRepository;
            _assertService = new AssertService<InvoiceDetail>(invoiceRepository);
        }

        public async Task<InvoiceDetail> Add(InvoiceDetail entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(entity));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<InvoiceDetail> Delete(int id)
        {
            InvoiceDetail invoiceDetail = await this.Get(id);

            return await this._invoiceRepository.Delete(invoiceDetail);
        }

        public async Task<List<InvoiceDetail>> DeleteByInvoices(List<int> invoiceId)
        {
            if (invoiceId == null || invoiceId.Count == 0) return new List<InvoiceDetail>();

            List<InvoiceDetail> detailsById = await this._invoiceRepository.GetMultiple(x => invoiceId.Contains(x.InvoiceId), true);

            return await this._invoiceRepository.DeleteAll(detailsById);
        }

        public async Task<InvoiceDetail> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(InvoiceDetail));

            return await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(InvoiceDetail));
        }

        public async Task<List<InvoiceDetail>> GetTenderItems(TenderItemsDto tenderItemsDto)
        {
            this._assertService.AssertNonZeroId(tenderItemsDto.CustomerId, nameof(InvoiceDetail));
            
            TenderMaster customerTender = await _tenderRepository.Get(x=>x.CustomerID.Equals(tenderItemsDto.CustomerId), true, new List<string>() { "FuelRate" });

            List<InvoiceDetail> tenderItems = new List<InvoiceDetail>();

            tenderItems.Add(getTenderAdjestmentItem(customerTender, tenderItemsDto));

            if(tenderItemsDto.TotalKm.Count > 0 && tenderItemsDto.AverageKM > 0) { 
                tenderItems.AddRange(getFueljestmentItem(customerTender, tenderItemsDto));
            }

            return tenderItems;
        }

        public async Task<List<InvoiceDetail>> GetAll(int invoiceId)
        {
            this._assertService.AssertNonZeroId(invoiceId, nameof(InvoiceDetail));

            return await this._invoiceRepository.GetMultipleInclude(x => x.InvoiceId.Equals(invoiceId), true, "Item");
        }

        public async Task<List<InvoiceDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<InvoiceDetail>> GetInvoiceDetail(int invoiceId)
        {
            this._assertService.AssertNonZeroId(invoiceId, nameof(InvoiceDetail));

            return await this._invoiceRepository.GetMultipleInclude(x => x.InvoiceId.Equals(invoiceId), true, new List<string>() { "Item", "VoucherDetail", "VoucherDetail.Voucher" });
        }

        public async Task<InvoiceDetail> Update(InvoiceDetail entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(InvoiceDetail));

            InvoiceDetail detailById = await this._assertService.AssertEntityExist(x=> x.Id.Equals(entity.Id), nameof(InvoiceDetail));

            detailById.ItemId = entity.ItemId;
            detailById.ItemCategory = entity.ItemCategory;
            detailById.Rate = entity.Rate;
            detailById.Amount = entity.Amount;
            detailById.AmountBeforeTax = entity.AmountBeforeTax;
            detailById.CGST = entity.CGST;
            detailById.SGST= entity.SGST;
            detailById.IGST = entity.IGST;
            detailById.Quantity = entity.Quantity;
            detailById.Description = entity.Description;

            return await this._invoiceRepository.Update(detailById);
        }

        private InvoiceDetail getTenderAdjestmentItem(TenderMaster tender, TenderItemsDto tenderItemsDto) 
        {
            ItemMaster sysItem = _itemRepository.Get(x => x.ItemName.Equals(Constants.SYS_ITEM_TENDER_ADJESTMENT), false).Result;

            double adjestmentAmount = tenderItemsDto.FixedCost * tender.AdjestmentPercentage / 100;

            if (tender.TenderType.Equals(TenderType.BELOW)) 
            {
                adjestmentAmount = - adjestmentAmount;
            }

            return new InvoiceDetail()
            {
                Item = sysItem,
                ItemId = sysItem.Id,
                ItemCategory = adjestmentAmount>0? "CHARGE":"COST",
                Rate = adjestmentAmount,
                Quantity = 1,
                AmountBeforeTax = adjestmentAmount,
                CGST = 0,
                SGST = 0,
                IGST = 0,
                Amount=adjestmentAmount,
                Description = "ADJESTMENT" + Environment.NewLine 
                + tender.TenderType.ToString() +" "
                + tender.AdjestmentPercentage.ToString() + "%" 
                + Environment.NewLine +" on: "
                + tenderItemsDto.FixedCost.ToString()
            };
        }

        private List<InvoiceDetail> getFueljestmentItem(TenderMaster tender, TenderItemsDto tenderItemsDto)
        {

            ItemMaster sysItem = _itemRepository.Get(x => x.ItemName.Equals(Constants.SYS_ITEM_FUEL_ADJESTMENT), false).Result;

            List<InvoiceDetail> fuelAdjestmentItems = new List<InvoiceDetail>();

            int currentIndex = 0;

            foreach (FuelRate singleChange in tender.FuelRate) 
            {
                if (!IsLastMonth(singleChange.FromDate) && 
                    !IsLastMonth(singleChange.ToDate))
                {
                    continue;
                }

                if (currentIndex > (tenderItemsDto.TotalKm.Count - 1)) 
                {
                    break;
                }
                double adjestmentAmount = (((singleChange.FuelCost - tender.FuelContractRate) * tenderItemsDto.TotalKm[currentIndex])/tenderItemsDto.AverageKM);

                fuelAdjestmentItems.Add(
                        new InvoiceDetail()
                        {
                            Item = sysItem,
                            ItemId = sysItem.Id,
                            ItemCategory = adjestmentAmount>0? "CHARGE":"COST",
                            Rate = adjestmentAmount,
                            Quantity = 1,
                            AmountBeforeTax = adjestmentAmount,
                            CGST = 0,
                            SGST = 0,
                            IGST = 0,
                            Amount= adjestmentAmount,
                            Description = "ADJESTMENT" + 
                            Environment.NewLine +
                            " From: "+ singleChange.FromDate.ToShortDateString() +
                            Environment.NewLine+
                            " To: " + singleChange.ToDate.ToShortDateString()+
                            Environment.NewLine +
                            " Old Rate: "+ tender.FuelContractRate.ToString() +
                            Environment.NewLine+
                            " New Rate: "+ singleChange.FuelCost.ToString() +
                            Environment.NewLine +
                            " Total K.M : " +  tenderItemsDto.TotalKm[currentIndex].ToString()
                        }
                    );
                currentIndex++;
            }

            return fuelAdjestmentItems;
        }
        private bool IsLastMonth(DateTime date)
        {
            DateTime lastMonth = DateTime.Today.AddMonths(-1);
            return date.Month == lastMonth.Month && date.Year == lastMonth.Year;
        }
        //private bool IsCurrentOrLastMonth(DateTime date)
        //{
        //    DateTime now = DateTime.Today;
        //    DateTime lastMonth = now.AddMonths(-1);

        //    return (date.Month == now.Month && date.Year == now.Year) ||
        //           (date.Month == lastMonth.Month && date.Year == lastMonth.Year);
        //}
    }
}
