namespace Invoice.Service
{
    public interface IService<T>
    {
        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<List<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Delete(int id);
    }
}
