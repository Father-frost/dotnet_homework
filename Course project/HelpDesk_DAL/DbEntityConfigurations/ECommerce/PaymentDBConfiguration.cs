using HelpDesk_DomainModel.Models.ECommerce;
using HelpDesk_DomainModel.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk_DAL.DbEntityConfigurations.Identity
{
    internal class PaymentDBConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {

        }
    }
}
