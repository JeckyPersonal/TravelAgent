using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();

            builder.Property(x => x.InvoiceNo).HasColumnName("invoice_no").HasColumnType("varchar").HasMaxLength(15);
            builder.Property(x => x.InvoiceDate).HasColumnName("invoice_date").HasColumnType("date");
            builder.Property(x => x.StartingKM).HasColumnName("starting_KM").HasColumnType("int");
            builder.Property(x => x.StartingTime).HasColumnName("starting_time").HasColumnType("datetime");
            //builder.Property(x => x.StateCode).HasColumnName("state_code").HasColumnType("varchar").HasMaxLength(15);
            //builder.Property(x => x.SACCode).HasColumnName("sac_code").HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.Total).HasColumnName("total").HasColumnType("money");
            builder.Property(x => x.CGST).HasColumnName("c_gst").HasColumnType("money");
            builder.Property(x => x.SGST).HasColumnName("s_gst").HasColumnType("money");
            builder.Property(x => x.IGST).HasColumnName("i_gst").HasColumnType("money");
            builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("money");

            //builder.Property(x => x.DriverId).HasColumnName("driver_id");
            builder.Property(x => x.FinancialYearId).HasColumnName("financial_year_id");
            builder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired();
            builder.Property(x => x.BankDetailId).HasColumnName("bank_detail_id").IsRequired();
            builder.Property(x => x.Status).HasColumnName("invoice_status").HasConversion<string>().IsRequired().HasMaxLength(20);

            //builder.Property(x => x.VehicleDetailId).HasColumnName("vehicle_detail_id");

            //builder.HasOne(x => x.Driver).WithMany(x => x.Invoices).HasForeignKey(x => x.VehicleDetailId).HasConstraintName("FK_INVOICE_DRIVER");
            builder.HasOne(x => x.FinancialYear).WithMany(x => x.Invoices).HasForeignKey(x => x.FinancialYearId).HasConstraintName("FK_INVOICE_FINANCIAL_YEAR");
            builder.HasOne(x => x.Customer).WithMany(x => x.Invoices).HasForeignKey(x => x.CustomerId).HasConstraintName("FK_INVOICE_CUSTOMER_ID").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.BankDetail).WithMany(x => x.Invoices).HasForeignKey(x => x.BankDetailId).HasConstraintName("FK_INVOICE_BANK_DETAIL_ID").OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(x => x.VehicleDetail).WithMany(x => x.Invoices).HasForeignKey(x => x.VehicleDetailId).HasConstraintName("FK_INVOICE_VEHICLE_DETAIL");
        }
    }
}
