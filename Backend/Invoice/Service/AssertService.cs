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

        public async Task<T> AssertDuplicationEntity(Expression<Func<T, bool>> expression, Func<T, bool> validation, string name)
        {
            T entity = await this._repository.Get(expression, true);

            if (entity != null && validation.Invoke(entity))
                throw new DuplicateEntityException($"Company '{name}' is already exist. Please re-try with different company name.");

            return entity;
        }
    }
}
