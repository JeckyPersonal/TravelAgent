using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Model.Config
{
    public class BankDetailConfiguration : IEntityTypeConfiguration<BankDetail>
    {
        public void Configure(EntityTypeBuilder<BankDetail> builder)
        {
            builder.ToTable("bank_detail");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x=> x.AccountNumber).HasColumnName("account_number").HasColumnType("varchar").HasMaxLength(25).IsRequired();
            builder.Property(x => x.IFSCCode).HasColumnName("isfc_code").HasColumnType("varchar").HasMaxLength(25).IsRequired();
            builder.Property(x => x.BankId).HasColumnName("bank_id");

            builder.HasOne(x => x.Bank).WithMany(x => x.BankDetail).HasForeignKey(x => x.BankId).HasConstraintName("FK_BANK_DETAIL_BANK").IsRequired();
        }
    }
}
