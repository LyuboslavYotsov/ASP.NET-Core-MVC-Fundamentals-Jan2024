
using System.ComponentModel.DataAnnotations;
using static Contacts.Data.DataConstants;

namespace Contacts.Models.Contact
{
    public class ContactFormViewModel
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            ContactFirstNameMaxLength,
            MinimumLength = ContactFirstNameMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(
            ContactLastNameMaxLength,
            MinimumLength = ContactLastNameMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [EmailAddress]
        [StringLength(
            ContactEmailMaxLength,
            MinimumLength = ContactEmailMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Phone]
        [StringLength(
            ContactPhoneNumberMaxLength,
            MinimumLength = ContactPhoneNumberMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public string Website { get; set; } = string.Empty;
    }
}
