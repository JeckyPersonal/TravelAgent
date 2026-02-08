using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class TenderConfiguration : IEntityTypeConfiguration<TenderMaster>
    {
        public void Configure(EntityTypeBuilder<TenderMaster> builder)
        {
            builder.ToTable("tender");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();

            builder.Property(x => x.FuelContractRate).HasColumnName("fix_rate");
            builder.Property(x => x.TenderType).HasColumnName("contract_type").HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.AdjestmentPercentage).HasColumnName("diff_per").HasColumnType("float");


            builder.HasOne(x => x.Customer).WithMany(x => x.Tenders).HasForeignKey(x => x.CustomerID).HasConstraintName("FK_CUSTOMER_TENDER");
            builder.HasOne(x => x.FinancialYear).WithMany(x => x.Tenders).HasForeignKey(x => x.FinancialYearId)
                .HasConstraintName("FK_TENDER_FYEAR")
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
