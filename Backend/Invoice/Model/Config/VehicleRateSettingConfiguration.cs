using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class VehicleRateSettingConfiguration : IEntityTypeConfiguration<VehicleRateConfiguration>
    {
        public void Configure(EntityTypeBuilder<VehicleRateConfiguration> builder)
        {
            builder.ToTable("vahicle_rate_configuration");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().HasColumnName("id");

            builder.Property(x=> x.ItemId).HasColumnName("item_id").IsRequired();
            builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
            builder.Property(x => x.CustomerId).HasColumnName("customer_id");
            builder.Property(x => x.Type).HasColumnName("configuration_type").HasColumnType("varchar(15)").IsRequired();
            

            builder.HasOne(x => x.Vehicle).WithMany(x => x.VehicleRates).HasForeignKey(x => x.VehicleId).HasConstraintName("FK_VEHICLE_RATES_VEHICLE_DETAIL").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=> x.ItemMaster).WithMany(x=> x.VehicleRates).HasForeignKey(x=> x.ItemId).HasConstraintName("FK_VEHICLE_RATES_ITEM_DETAIL").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Customer).WithMany(x => x.RateConfigurations).HasForeignKey(x => x.CustomerId).HasConstraintName("FK_VEHICLE_CUSTOER_RATE_DETAIL").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
