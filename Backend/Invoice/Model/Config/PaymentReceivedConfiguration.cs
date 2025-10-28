using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace Invoice.Model.Config
{
    public class PaymentReceivedConfiguration : IEntityTypeConfiguration<PaymentReceived>
    {
        public void Configure(EntityTypeBuilder<PaymentReceived> builder)
        {
            builder.ToTable("payment_received");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x=> x.ReveivedDate).HasColumnName("receive_date").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.PaymentAmount).HasColumnName("payment_amount").HasColumnType("money").IsRequired();
            builder.Property(x=> x.TDS).HasColumnName("tds").HasColumnType("money").IsRequired();
            builder.Property(x => x.CGST).HasColumnName("c_gst").HasColumnType("money").IsRequired();
            builder.Property(x => x.SGST).HasColumnName("s_gst").HasColumnType("money").IsRequired();
            builder.Property(x => x.IGST).HasColumnName("i_gst").HasColumnType("money").IsRequired();
            builder.Property(x=> x.ReceivedAmount).HasColumnName("receive_amount").HasColumnType("money").IsRequired(true);
            builder.Property(x => x.InvoiceId).HasColumnName("invoice_id").IsRequired();
            builder.Property(x => x.FinancialYearId).HasColumnName("financial_year_id").IsRequired();
            builder.Property(x => x.ReferenceNumber).HasColumnName("reference_number").IsRequired().HasColumnType("varchar").HasMaxLength(30);

            builder.HasOne(x=> x.Invoice).WithMany(x=> x.PaymentReceived).HasForeignKey(x=>x.InvoiceId).HasConstraintName("FK_INVOICE_PAYMENT");
            builder.HasOne(x=> x.FinancialYear).WithMany(x=> x.Payments).HasForeignKey(x=> x.FinancialYearId).HasConstraintName("FK_FINANCIAL_YEAR_PAYMENT");

        }
    }
}
