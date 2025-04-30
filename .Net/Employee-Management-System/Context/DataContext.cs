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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.FullName).HasComputedColumnSql("FirstName + ' ' + LastName", stored: false);
        }
    }
}
