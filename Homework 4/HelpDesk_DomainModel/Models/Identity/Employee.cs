using System.ComponentModel.DataAnnotations;

namespace HelpDesk_DomainModel.Models.Identity
{
    public class Employee : Entity<long>
    {
        [MaxLength(100)]
        public required string FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(100)]
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
