using HelpDesk_DomainModel.Models.Identity;

namespace HelpDesk_BLL.Contracts.Identity
{
    public class UserCreateModel : UserBriefModel
    {
        public required string Password { get; set; }
    }
}
