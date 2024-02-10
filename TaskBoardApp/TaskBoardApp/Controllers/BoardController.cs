using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Board;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {

        private readonly TaskBoardAppDbContext _context;

        public BoardController(TaskBoardAppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var boards = await _context.Boards
                .AsNoTracking()
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.User.UserName,
                    })

                })
                .ToListAsync();


            return View(boards);
        }
    }
}
