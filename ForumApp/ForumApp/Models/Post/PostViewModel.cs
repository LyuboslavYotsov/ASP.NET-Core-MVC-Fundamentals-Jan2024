using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.DataConstants.PostConst;

namespace ForumApp.Models.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = string.Empty;
    }
}
