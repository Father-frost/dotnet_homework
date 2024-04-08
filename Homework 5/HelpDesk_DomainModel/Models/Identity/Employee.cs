using System.ComponentModel.DataAnnotations;

namespace HelpDesk_DomainModel.Models.Identity
{
	public class Employee : Entity<long>
	{
		[MaxLength(100)]
		[MinLength(2, ErrorMessage = "The First Name is too short!")]
		[Required(ErrorMessage = "First Name is required!")]
		public required string FirstName { get; set; }
		[MaxLength(100)]
		[MinLength(2, ErrorMessage = "The Last Name is too short!")]
		public string? LastName { get; set; }
		[MaxLength(100)]
		[Required(ErrorMessage = "Email is required!")]
		public required string Email { get; set; }
		public required PostEnum Post { get; set; }
		[MaxLength(200)]
		public string? Skills { get; set; }

		public string FullName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(LastName))
				{
					return FirstName;
				}
				return $"{FirstName} {LastName}";
			}
		}
	}
}
