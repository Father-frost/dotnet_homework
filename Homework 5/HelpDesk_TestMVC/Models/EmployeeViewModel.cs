using HelpDesk_TestMVC.Enums;

namespace HelpDesk_TestMVC.Models
{
	public class EmployeeViewModel
	{
		public long Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public required string Email { get; set; }
		public PostEnum Post { get; set; }
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
