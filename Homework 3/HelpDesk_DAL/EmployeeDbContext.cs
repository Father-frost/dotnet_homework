using Microsoft.EntityFrameworkCore;

namespace HelpDesk_DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        // public DbSet<Feedback> Feedbacks;
        // public DbSet<Order> Orders;
        // ... - use ApplyConfigurationsFromAssembly instead and create configs for entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
