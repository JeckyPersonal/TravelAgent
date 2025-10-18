using Invoice.Model.Config;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Model
{
    public class InvoiceDBContext : DbContext
    {
        private readonly IAppContext _appContext;
        public InvoiceDBContext(DbContextOptions<InvoiceDBContext> options, IAppContext appContext) : base(options)
        {
            this._appContext = appContext;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<Customer>().HasQueryFilter(c=> c.CompanyId == _appContext.CompanyId);
            modelBuilder.Entity<Bank>().HasQueryFilter(c => c.CompanyId == _appContext.CompanyId);
            modelBuilder.Entity<Driver>().HasQueryFilter(x => x.CompanyId == _appContext.CompanyId);
            modelBuilder.Entity<FinancialYear>().HasQueryFilter(x => x.CompanyId == _appContext.CompanyId);
            modelBuilder.Entity<ItemMaster>().HasQueryFilter(x => x.CompanyId == _appContext.CompanyId);
            modelBuilder.Entity<Vehicle>().HasQueryFilter(x => x.CompanyId == _appContext.CompanyId);
            modelBuilder.Entity<Invoice>().HasQueryFilter(x => x.FinancialYearId == _appContext.AccYearId);
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
        public DbSet<VehicleRateConfiguration> VehicleRates { get; set; }

        private void SetCompanyIds()
        {
            foreach (var entry in ChangeTracker.Entries<ICompanyOwnedEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CompanyId = this._appContext.CompanyId;
                }
            }
        }

        private void SetAccountYearIds()
        {
            foreach (var entry in ChangeTracker.Entries<IFinancialYearOwnerEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.FinancialYearId = this._appContext.AccYearId;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.SetCompanyIds();
            this.SetAccountYearIds();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
