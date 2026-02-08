using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class FuelRateConfiguration : IEntityTypeConfiguration<FuelRate>
    {
        public void Configure(EntityTypeBuilder<FuelRate> builder)
        {
            builder.ToTable("fuel_rate");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();

            builder.Property(x => x.FromDate).HasColumnName("from_Date").HasColumnType("date");
            builder.Property(x => x.ToDate).HasColumnName("to_Date").HasColumnType("date");
            builder.Property(x => x.FuelCost).HasColumnName("prise");

            builder.HasOne(x => x.Tenders).WithMany(x => x.FuelRate).HasForeignKey(x => x.TenderID).HasConstraintName("FK_TENDER_FUEL");
            
        }
    }
}
