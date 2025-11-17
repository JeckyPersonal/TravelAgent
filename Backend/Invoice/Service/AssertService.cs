using Invoice.Exceptions;
using Invoice.Repository;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Invoice.Service
{
    public class AssertService<T>
    {
        private readonly IInvoiceRepository<T> _repository;
        public AssertService(IInvoiceRepository<T> repository) {
            this._repository = repository;
        }

        public void AssertZeroId( int id, string entityName)
        {
            if(id > 0)
            {
                throw new SavedEntityException($"Id should be zero while adding {entityName}. Please re-try with zero Id.");
            }
        }

        public void AssertNonZeroId(int id, string entityName)
        {
            if (id == 0)
                throw new SavedEntityException($"The {entityName} id should be grater then zero for edit operation. Please re-try with valid id.");
        }

        public void AssertDuplicationEntity(Expression<Func<T, bool>> expression, Func<T, bool> validation, string name, bool noTracking = true)
        {
            T entity = this._repository.Get(expression, noTracking).Result;

            if (entity != null && validation.Invoke(entity))
                throw new DuplicateEntityException($"'{name}' is already exist. Please re-try with different name.");
        }

        public async Task<T> AssertEntityExist(Expression<Func<T, bool>> expression, string entityName)
        {
            T entity = await this._repository.Get(expression, true);

            if(entity == null)
                throw new EntityNotFoundException($"{entityName} is not found. Please ret-try with different value.");

            return entity;
        }

        public async Task<T> AssertEntityExist(Expression<Func<T, bool>> expression, string entityName, string navigationPath)
        {
            if (string.IsNullOrWhiteSpace(navigationPath))
                throw new ArgumentException("Argument 'navigationPath' is null or blank. Please retry after passing non-blank value.");

            T entity = await this._repository.Get(expression, true, navigationPath);

            if (entity == null)
                throw new EntityNotFoundException($"{entityName} is not found. Please ret-try with different value.");

            return entity;
        }

    }
}
