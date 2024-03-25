using HelpDesk_DomainModel.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk_DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        //public DbSet<Employee> Employees;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
