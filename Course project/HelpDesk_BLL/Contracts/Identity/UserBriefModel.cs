using HelpDesk_DomainModel.Models;
using HelpDesk_DomainModel.Models.Identity;

namespace HelpDesk_BLL.Contracts.Identity
{
    public class UserBriefModel
    {
        public string? Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public required UserRoleEnum Role { get; set; }

    }
}
