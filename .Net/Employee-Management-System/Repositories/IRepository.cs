namespace Employee_Management_System.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(object key, T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(int pageNum, int pageSize = 5);

        void SaveChanges();

    }
}
