using HelpDesk_DomainModel.Models.ECommerce;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk_BLL.Contracts
{
    public class OrderDTO
    {
		[MaxLength(100)]
		[MinLength(2, ErrorMessage = "The Order text is too short!")]
		[Required(ErrorMessage = "Order Text is required!")]
		public required string OrderText { get; set;}
		[Required(ErrorMessage = "Address is required!")]
		public string? Address { get; set; }
		[Required(ErrorMessage = "Phone is required!")]
		public string? Phone { get; set; }
		[Required(ErrorMessage = "Minimal cost is required!")] 
		public decimal MinCost { get; set; }
		[Required(ErrorMessage = "Maximal cost is required!")]
		public decimal MaxCost { get; set; }
    }
}
