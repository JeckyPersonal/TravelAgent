using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Address1).HasColumnName("address_1").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Address2).HasColumnName("address_2").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Address3).HasColumnName("address_3").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.GSTNo).HasColumnName("gst_no").HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.CessNo).HasColumnName("cess_no").HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.PANNo).HasColumnName("pan_no").HasColumnName("varchar").HasMaxLength(15);
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_no").HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.City).HasColumnName("city").HasColumnType("varchar").HasMaxLength(15);
            builder.Property(x => x.State).HasColumnName("state").HasColumnType("varchar").HasMaxLength(10);
            builder.Property(x => x.Country).HasColumnName("country").HasColumnType("varchar").HasMaxLength(25);
            builder.Property(x => x.Zip).HasColumnName("zip").HasColumnType("varchar").HasMaxLength(10);
            builder.Property(x => x.TripRate).HasColumnName("trip_rate");
            builder.Property(x => x.CompanyId).HasColumnName("company_id");

            builder.HasOne(x => x.Company).WithMany(x => x.Customers).HasForeignKey(x => x.CompanyId).HasConstraintName("FK_CUSTOMER_COMPANY").IsRequired();
        }
    }
}
