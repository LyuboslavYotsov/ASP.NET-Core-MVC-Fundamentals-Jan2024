using Homies.Data.Models;
using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;

namespace Homies.Models
{
    public class EventFormViewModel
    {
        [Required(ErrorMessage = ReqiredFieldMessage)]
        [StringLength(
            EventNameMaxLength,
            MinimumLength = EventNameMinLength,
            ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ReqiredFieldMessage)]
        [StringLength(
            EventDescriptionMaxLength,
            MinimumLength = EventDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = ReqiredFieldMessage)]
        public string Start { get; set; } = string.Empty;

        [Required(ErrorMessage = ReqiredFieldMessage)]
        public string End { get; set; } = string.Empty;

        [Required(ErrorMessage = ReqiredFieldMessage)]
        public int TypeId { get; set; }

        public ICollection<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
