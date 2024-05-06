using HelpDesk_DomainModel.Models.Identity;

namespace HelpDesk_DomainModel.Models.ECommerce
{
    public class Order : Entity<long>
    {
        public required User User { get; set; }
        public long? EmployeeId { get; set; }
        public string? UserId { get; set; }
        
        public required string OrderText { get; set;}
        public required DateTime Date {get; set;}

        public string? Address { get; set;}
        public string? Phone { get; set;}
        public required OrderStatusEnum Status { get; set; }
        public decimal MinCost { get; set; }
        public decimal MaxCost { get; set; }

    }
}
