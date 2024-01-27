using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext _context;

        public PostController(ForumAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _context.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();

            return View(posts);
        }

        public async Task<IActionResult> Add()
        => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
            };

            await _context.Posts.AddAsync(post);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            return View(new PostViewModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,PostViewModel model)
        {
            var post = await _context.Posts.FindAsync(id);

            post.Title = model.Title;
            post.Content = model.Content;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
