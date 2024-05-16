using Microsoft.EntityFrameworkCore;
using time_of_your_life.Data;
using time_of_your_life.Interfaces;

namespace time_of_your_life.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DataContext _appDbContext;

        public BaseRepository(DataContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            return Task.CompletedTask;
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _appDbContext.Set<T>().AsNoTracking();
        }

        public T? GetById(Guid id)
        {
            return _appDbContext.Set<T>().Find(id);
        }

        public Task Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
            return Task.CompletedTask;
        }
    }
}
