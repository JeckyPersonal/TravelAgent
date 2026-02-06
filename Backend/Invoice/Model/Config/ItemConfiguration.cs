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
            builder.Property(x => x.ItemDescription).HasColumnName("item_des").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.ItemCatogery).HasColumnName("item_catogery").HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.ItemSource).HasColumnName("item_source").HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.Rate).HasColumnName("item_rate").HasColumnType("money");
            builder.Property(x => x.AppliedGST).HasColumnName("applied_gst").HasColumnName("bit");
            builder.Property(x => x.CompanyId).HasColumnName("company_id");
            builder.Property(x => x.Quantity).HasColumnName("item_quantity");
            builder.Property(x => x.Unit).HasColumnName("item_unit");
            builder.Property(x=> x.IntervalId).HasColumnName("internal_id").IsRequired(false);

            builder.HasOne(x => x.Company).WithMany(x => x.Items).HasForeignKey(x => x.CompanyId).HasConstraintName("FK_ITEM_COMPANY");
            builder.HasOne(x => x.Interval).WithMany(x => x.Items).HasForeignKey(x => x.IntervalId).HasConstraintName("FK_ITEM_INTERVAL");
        }
    }
}
