using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class VoucherMasterConfiguration : IEntityTypeConfiguration<VoucherMaster>
    {
        public void Configure(EntityTypeBuilder<VoucherMaster> builder)
        {
            builder.ToTable("voucher_master");

            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.Id).UseIdentityColumn();

            builder.Property(x => x.VoucherDate).HasColumnName("voucher_date").IsRequired();
            builder.Property(x => x.FromDate).HasColumnName("from_date").IsRequired();
            builder.Property(x => x.ToDate).HasColumnName("to_date").IsRequired();
            builder.Property(x => x.PickupLocation).HasColumnName("pickup_location").IsRequired();
            builder.Property(x => x.DropLocation).HasColumnName("drop_location").IsRequired();
            builder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired();
            builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
            builder.Property(x => x.RegistrationId).HasColumnName("registration_id").IsRequired(false);
            builder.Property(x => x.FinancialYearId).HasColumnName("financial_year_id");
            builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired(false);
            builder.Property(x => x.InvoiceId).HasColumnName("invoice_id").IsRequired(false);
            builder.Property(x => x.voucherStatus).HasColumnName("voucher_status").HasConversion<string>().IsRequired();

            builder.HasOne(x => x.Customer).WithMany(x => x.Vouchers).HasForeignKey(x => x.CustomerId).HasConstraintName("FK_VOUCHER_CUSTOMER").IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=> x.Vehicle).WithMany(x=> x.Vouchers).HasForeignKey(x=> x.VehicleId).HasConstraintName("FK_VOUCHER_VEHICLE").IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=> x.VehicleDetail).WithMany(x=> x.Vouchers).HasForeignKey(x=> x.RegistrationId).HasConstraintName("FK_VOUCHER_REGISTRATION").IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.FinancialYear).WithMany(x => x.Vouchers).HasForeignKey(x => x.FinancialYearId).HasConstraintName("FK_VOUCHER_FINANCIAL_YEAR_ID").IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=> x.Driver).WithMany(x=> x.Vouchers).HasForeignKey(x=> x.DriverId).HasConstraintName("FK_VOUCHER_DRIVER").IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Invoice).WithMany(x => x.Vouchers).HasForeignKey(x => x.InvoiceId).HasConstraintName("FK_VOUCHER_INVOICE").IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
    