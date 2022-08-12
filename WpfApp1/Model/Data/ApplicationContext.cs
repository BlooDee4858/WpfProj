using Microsoft.EntityFrameworkCore;

namespace WpfProject.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companys { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }  

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database = Company; Trusted_Connection = True");
        }
    }
}
