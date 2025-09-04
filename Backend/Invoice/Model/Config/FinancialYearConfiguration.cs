using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class FinancialYearConfiguration : IEntityTypeConfiguration<FinancialYear>
    {
        public void Configure(EntityTypeBuilder<FinancialYear> builder)
        {
            builder.ToTable("financial_year");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().HasColumnName("id");

            builder.Property(x => x.FromDate).HasColumnName("from_date").HasColumnType("datetime");
            builder.Property(x => x.ToDate).HasColumnName("to_date").HasColumnType("datetime");
            builder.Property(x => x.CompanyId).HasColumnName("company_id");

            builder.HasOne(x=> x.Company).WithMany(x=>x.FinancialYears).HasForeignKey(x=>x.CompanyId).HasConstraintName("FK_FINANCIAL_YEAR_COMPANY");
        }
    }
}
