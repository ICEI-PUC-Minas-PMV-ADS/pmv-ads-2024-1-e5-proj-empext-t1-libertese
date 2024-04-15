namespace Libertese.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);

        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> Delete(int id);

        Task<T> Update(T entity);
    }
}
