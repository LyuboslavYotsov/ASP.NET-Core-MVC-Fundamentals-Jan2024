using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TaskConstants.TaskMaxTitle)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.TaskConstants.TaskMaxDescription)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser User { get; set; } = null!;
    }
}
