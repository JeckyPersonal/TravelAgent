using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class ItemConfiguration : IEntityTypeConfiguration<ItemMaster>
    {
        public void Configure(EntityTypeBuilder<ItemMaster> builder)
        {
            builder.ToTable("item");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();

            builder.Property(x => x.ItemName).HasColumnName("name").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Rate).HasColumnName("item_rate").HasColumnType("money");
            builder.Property(x => x.AppliedGST).HasColumnName("applied_gst").HasColumnName("bit");
            builder.Property(x => x.CompanyId).HasColumnName("company_id");

            builder.HasOne(x => x.Company).WithMany(x => x.Items).HasForeignKey(x => x.CompanyId).HasConstraintName("FK_ITEM_COMPANY");
        }
    }
}
