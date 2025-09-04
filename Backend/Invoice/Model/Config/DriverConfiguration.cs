using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("driver");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();

            builder.Property(x => x.DriverName).HasColumnName("driver_name").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.LicenseNo).HasColumnName("license_no").HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.DriverMobile).HasColumnName("driver_mobile").HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.CompanyId).HasColumnName("company_id");

            builder.HasOne(x => x.Company).WithMany(x => x.Drivers).HasForeignKey(x => x.CompanyId).HasConstraintName("FK_DRIVER_COMPANY");


        }
    }
}
