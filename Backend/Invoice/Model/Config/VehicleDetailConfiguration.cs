using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class VehicleDetailConfiguration : IEntityTypeConfiguration<VehicleDetail>
    {
        public void Configure(EntityTypeBuilder<VehicleDetail> builder)
        {
            builder.ToTable("vehicle_detail");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().HasColumnName("id");

            builder.Property(x => x.RegistrationNumber).HasColumnName("registration_number").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.VehicleId).HasColumnName("vehicle_id");

            builder.HasOne(x=> x.Vehicle).WithMany(x=>x.Vehicles).HasForeignKey(x=> x.VehicleId).HasConstraintName("FK_VEHICLE_DETAIL_VEHICLE");
        }
    }
}
