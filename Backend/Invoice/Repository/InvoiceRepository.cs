using Invoice.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace Invoice.Repository
{
    public class InvoiceRepository<T> : IInvoiceRepository<T> where T : class
    {

        private readonly InvoiceDBContext _invoiceDBContext;
        private readonly DbSet<T> _dbSet;

        public InvoiceRepository(InvoiceDBContext invoiceDBContext)
        {
            _invoiceDBContext = invoiceDBContext;
            _dbSet = invoiceDBContext.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            this._dbSet.Add(entity);
            await this._invoiceDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, bool noTracking)
        {
            if (!noTracking)
                return await this._dbSet.Where(expression).FirstOrDefaultAsync();
            else
                return await this._dbSet.AsNoTracking().Where(expression).FirstOrDefaultAsync(); 
        }

        public async Task<List<T>> GetMultiple(Expression<Func<T, bool>> expression, bool noTracking)
        {
            if (!noTracking)
                return await this._dbSet.Where(expression).ToListAsync();
            else
                return await this._dbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<List<T>> GetMultipleInclude(Expression<Func<T, bool>> expression, bool noTracking, string navigationPath)
        {
            IQueryable<T> query = this._dbSet;

            if(!string.IsNullOrWhiteSpace(navigationPath))
                query = query.Include(navigationPath);

            if(noTracking) query= query.AsNoTracking();

            return await query.Where(expression).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await this._dbSet.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            this._dbSet.Update(entity);
            await this._invoiceDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            this._dbSet.Remove(entity);
            await this._invoiceDBContext.SaveChangesAsync();
            return entity;
        }
    }
}
