using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data;

namespace TaskBoardApp.Models.Task
{
    public class TaskViewModel
    {
        public int Id { get; init; }

        [Required]
        [StringLength(DataConstants.TaskConstants.TaskMaxTitle,
            MinimumLength = DataConstants.TaskConstants.TaskMinTitle)]
        public string Title { get; init; } = null!;

        [Required]
        [StringLength(DataConstants.TaskConstants.TaskMaxDescription,
            MinimumLength = DataConstants.TaskConstants.TaskMinDescription)]
        public string Description { get; set; } = null!;

        [Required]
        public string Owner { get; init; } = null!;
    }
}
