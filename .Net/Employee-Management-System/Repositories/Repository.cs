
using Employee_Management_System.Context;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext dbContext;
        public Repository(DataContext context)
        {
            dbContext = context;
        }
        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }
        public IEnumerable<T> GetAll(int pageNum, int pageSize = 5)
        {
            return dbContext.Set<T>()
                .Skip((pageNum -1) * pageSize) //one-indexed
                .Take(pageSize);
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().FindAsync(id).Result!;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;
        }

    }
}
