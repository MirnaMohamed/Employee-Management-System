
using Employee_Management_System.Context;

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
            dbContext.Set<T>().Update(entity);
        }

    }
}
