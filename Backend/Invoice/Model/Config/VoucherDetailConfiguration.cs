using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class VoucherDetailConfiguration : IEntityTypeConfiguration<VoucherDetail>
    {
        public void Configure(EntityTypeBuilder<VoucherDetail> builder)
        {
            builder.ToTable("voucher_detail");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ItemId).HasColumnName("item_id").IsRequired();
            builder.Property(x => x.VoucherId).HasColumnName("voucher_id").IsRequired();
            builder.Property(x => x.Amount).HasColumnName("amount").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("quantity").IsRequired();
            builder.Property(x => x.InvoiceDetailId).HasColumnName("invoice_detail_id").IsRequired(false);

            builder.HasOne(x => x.Item).WithMany(x => x.VoucherDetails).HasForeignKey(x => x.ItemId).HasConstraintName("FK_VOUCHER_DETAIL_ITEM").IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Voucher).WithMany(x => x.Details).HasForeignKey(x => x.VoucherId).HasConstraintName("FK_VOUCHER_DETAIL_VOUCHER_MASTER").IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.InvoiceDetail).WithOne(x => x.VoucherDetail).HasForeignKey<VoucherDetail>(x => x.InvoiceDetailId).HasConstraintName("FK_VOUCHER_DETAIL_INVOICE_DETAIL").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
