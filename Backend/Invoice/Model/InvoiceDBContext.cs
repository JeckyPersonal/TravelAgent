using Invoice.Model.Config;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Model
{
    public class InvoiceDBContext : DbContext
    {
        public InvoiceDBContext(DbContextOptions<InvoiceDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            //modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            //modelBuilder.ApplyConfiguration(new BankConfiguration());
            //modelBuilder.ApplyConfiguration(new BankDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankDetail> BankDetail { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<ItemMaster> Items { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }
    }
}
