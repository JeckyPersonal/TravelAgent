using System;

namespace Invoice.UI.DTO
{
    public class VoucherMasterDto
    {
        public int Id { get; set; }
        public DateTime VoucherDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public int RegistrationId { get; set; }
        public string RegistrationNo { get; set; }
        public int FinancialYearId { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string VoucherNo { get; set; }
        public int Days { get; set; }
        public VoucherStatus voucherStatus { get; set; }
        public string VisitorName { get; set; }
        public string StartFrom { get; set; }
        public string EndFrom { get; set; }
        public BillingWorkType BillingWorkType { get; set; }
    }

    public enum BillingWorkType
    {
        NONE,
        KM,
        TIME
    }

    public enum VoucherStatus
    {
        New,
        Invoice_Created
    }
}
