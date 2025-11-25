using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler
{
    public class VoucherProcessor
    {
        private readonly IVoucherDetailService _voucherDetailService;
        private readonly ICustomerService _customerService;

        public VoucherProcessor(IVoucherDetailService voucherDetailService, ICustomerService customerService)
        {
            this._voucherDetailService = voucherDetailService;
            this._customerService = customerService;

        }

        public List<InvoiceDetailDto> Process(VoucherProcessDto processDto)
        {
            List<VoucherDetail> voucherDetails = this._voucherDetailService.GetAllByVoucherIds(processDto.VoucherIds).Result;

            if (processDto.ExcludedDetailId != null && processDto.ExcludedDetailId.Count > 0)
                voucherDetails = voucherDetails.Where(x => !processDto.ExcludedDetailId.Contains(x.Id)).Select(x => x).ToList();

            List<InvoiceDetailDto> invoiceDetailDtos = new List<InvoiceDetailDto>();

            foreach (VoucherDetail detail in voucherDetails)
            {
                Customer customerById = this._customerService.Get(detail.Voucher.CustomerId).Result;

                bool hasCessNo = !string.IsNullOrWhiteSpace(customerById.CessNo);
                bool? isAppliedGST = detail.Item.AppliedGST;
                string GSTNo = customerById.GSTNo;
                bool isIGSTApplied = customerById.TaxCategory.Equals(TaxCategory.GST) && !GSTNo.StartsWith("24");

                double amountBeforeGST = calculateIGST(isAppliedGST.Value, detail.Amount, customerById.TaxCategory);
                double GST = detail.Amount - amountBeforeGST;


                InvoiceDetailDto detailDto = new InvoiceDetailDto()
                {
                    Id = 0,
                    ItemId = detail.Item.Id,
                    ItemName = detail.Item.ItemName,
                    Quantity = (int)detail.Item.Quantity.Value,
                    Rate = Math.Floor(detail.Rate * 100) / 100,
                    Unit = detail.Item.Unit,
                    Amount = Math.Floor(detail.Amount * 100) / 100,
                    Description = $"{detail.Voucher.PickupLocation} - {detail.Voucher.DropLocation}",
                    VoucherNo = detail.Voucher.VoucherNo,
                    VoucherDetailId = detail.Id
                };

                if (isIGSTApplied)
                {
                    detailDto.IGST = GST;
                    detailDto.AmountBeforeGST = Math.Floor(amountBeforeGST * 100) / 100;
                }
                else
                {
                    detailDto.AmountBeforeGST = Math.Floor(amountBeforeGST * 100) / 100;
                    detailDto.CGST = GST / 2;
                    detailDto.SGST = GST / 2;

                    detailDto.CGST = Math.Floor(detailDto.CGST * 100) / 100;
                    detailDto.SGST = Math.Floor(detailDto.SGST * 100) / 100;
                }

                invoiceDetailDtos.Add(detailDto);
            }

            return invoiceDetailDtos;
        }

        private double calculateIGST(bool isGSTApplied, double amount, TaxCategory taxCategory)
        {
            if (!isGSTApplied) return amount;

            if (taxCategory == TaxCategory.GST) return 0.00;

            return (100 * amount) / 105;
        }
    }
}
