using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            //builder.HasQueryFilter(x => x.CompanyId.Equals(this._appContext.CompanyId));
            builder.ToTable("bank");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x=> x.BankName).HasColumnName("bank_name").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.CompanyId).HasColumnName("company_id");

            builder.HasOne(x => x.Company).WithMany(x => x.Banks).HasForeignKey(x => x.CompanyId).HasConstraintName("FK_BANK_COMPANY").IsRequired();
        }
    }
}
