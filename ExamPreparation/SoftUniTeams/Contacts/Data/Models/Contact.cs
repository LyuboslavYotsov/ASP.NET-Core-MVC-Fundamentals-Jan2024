using System.ComponentModel.DataAnnotations;
using static Contacts.Data.DataConstants;

namespace Contacts.Data.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ContactFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(ContactLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(ContactEmailMaxLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(ContactPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; }

        [Required]
        public string Website { get; set; } = string.Empty;
    }
}
