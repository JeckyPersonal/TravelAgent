using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class InvoicePaymentConfiguration : IEntityTypeConfiguration<InvoicePayment>
    {
        public void Configure(EntityTypeBuilder<InvoicePayment> builder)
        {
            builder.ToTable("invoice_payment");

            builder.HasKey(x => new { x.InvoiceId, x.PaymentId });

            builder.HasOne(x=> x.Invoice).WithMany(x=> x.InvoicePayments).HasForeignKey(x=> x.InvoiceId).HasConstraintName("FK_INVOICE_INVOICE_PAYMENT");

            builder.HasOne(x => x.Payment).WithMany(x => x.InvoicePayments).HasForeignKey(x => x.PaymentId).HasConstraintName("FK_PAYMENT_INVOICE_PAYMENT");
        }
    }
}
