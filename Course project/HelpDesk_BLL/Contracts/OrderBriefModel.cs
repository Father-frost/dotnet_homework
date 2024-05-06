using HelpDesk_DomainModel.Models.ECommerce;
using HelpDesk_DomainModel.Models.Identity;

namespace HelpDesk_BLL.Contracts
{
    public class OrderBriefModel
    {
        public long? Id { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public string? EmployeeId { get; set; }
        public required string OrderText { get; set;}
        public required DateTime Date {get; set;}
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public required OrderStatusEnum Status { get; set; }
        public decimal MinCost { get; set; }
        public decimal MaxCost { get; set; }
    }
}
