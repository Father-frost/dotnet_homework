using HelpDesk_DomainModel.Models.ECommerce;
using HelpDesk_DomainModel.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk_DAL.DbEntityConfigurations.Identity
{
    internal class FeedbackDBConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            
        }
    }
}
