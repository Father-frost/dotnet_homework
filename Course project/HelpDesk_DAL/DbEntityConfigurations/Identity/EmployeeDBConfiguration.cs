using HelpDesk_DomainModel.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk_DAL.DbEntityConfigurations.Identity
{
    internal class EmployeeDBConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

        }
    }
}
