using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("vehicle");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().HasColumnName("id");

            builder.Property(x => x.VehicleType).HasColumnName("vehicle_type").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.CompanyId).HasColumnName("company_id");

            builder.HasOne(x => x.Company).WithMany(x => x.Vehicles).HasForeignKey(x => x.CompanyId).HasConstraintName("FK_VEHICLE_COMPANY");
        }
    }
}
