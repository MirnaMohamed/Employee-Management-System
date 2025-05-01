using Employee_Management_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DataContext()
        {
        }
    }
}
