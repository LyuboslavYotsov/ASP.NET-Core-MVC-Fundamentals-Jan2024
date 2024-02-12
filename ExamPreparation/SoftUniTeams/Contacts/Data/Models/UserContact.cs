using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.Models
{
    public class UserContact
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        public int ContactId { get; set; }

        [ForeignKey(nameof(ContactId))]
        public Contact Contact { get; set; } = null!;
    }
}
