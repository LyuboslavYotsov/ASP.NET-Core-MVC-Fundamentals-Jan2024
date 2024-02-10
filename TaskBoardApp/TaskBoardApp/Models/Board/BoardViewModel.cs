using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Models.Board
{
    public class BoardViewModel
    {
        public int Id { get; init; }

        [Required]
        [StringLength(
            DataConstants.BoardConstants.BoardMaxName,
            MinimumLength = DataConstants.BoardConstants.BoardMaxName)]
        public string Name { get; init; } = null!;

        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
