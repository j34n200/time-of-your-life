namespace time_of_your_life.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T? GetById(Guid id);
        IQueryable<T> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        Task Update(T entity);
    }
}
