using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("invoice_detail");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Rate).HasColumnName("rate").HasColumnType("money");
            builder.Property(x => x.Quantity).HasColumnName("quantity").HasColumnType("int");
            builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("money");
            builder.Property(x => x.ItemId).HasColumnName("item_id").HasColumnType("int");
            builder.Property(x => x.InvoiceId).HasColumnName("invoice_id").HasColumnType("int");

            builder.HasOne(x => x.Item).WithMany(x => x.InvoiceDetails).HasForeignKey(x => x.ItemId).HasConstraintName("FK_INVOICE_DETAIL_ITEM");
            builder.HasOne(x => x.Invoice).WithMany(x => x.InvoiceDetail).HasForeignKey(x => x.InvoiceId).HasConstraintName("FK_INVOICE_INVOICE_DETAIL");
        }
    }
}
