using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class ItemIntervalConfig : IEntityTypeConfiguration<ItemInterval>
    {
        public void Configure(EntityTypeBuilder<ItemInterval> builder)
        {
            builder.ToTable("item_interval");

            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).HasColumnName("id").IsRequired();

            builder.Property(x=> x.IntervalName).HasColumnName("interval_name").HasColumnType("varchar").HasMaxLength(25).IsRequired();
            builder.Property(x => x.Interval).HasColumnName("interval").HasColumnType("int").IsRequired();
        }
    }
}
