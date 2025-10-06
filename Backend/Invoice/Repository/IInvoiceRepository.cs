using System.Linq.Expressions;

namespace Invoice.Repository
{
    public interface IInvoiceRepository<T>
    {
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Get(Expression<Func<T, bool>> expression, bool asNoTracking);
        public Task<List<T>> GetMultiple(Expression<Func<T, bool>> expression, bool asNoTracking);
        public Task<List<T>> GetMultipleInclude(Expression<Func<T, bool>> expression, bool noTracking, string navigationPath);
        public Task<T> Delete(T entity);
        public Task<List<T>> GetAll();
    }
}
