using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data;

namespace TaskBoardApp.Models.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(DataConstants.TaskConstants.TaskMaxTitle,
                      MinimumLength = DataConstants.TaskConstants.TaskMinTitle,
                      ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;


        [Required]
        [StringLength(DataConstants.TaskConstants.TaskMaxDescription,
                      MinimumLength = DataConstants.TaskConstants.TaskMinDescription,
                      ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();
    }
}
