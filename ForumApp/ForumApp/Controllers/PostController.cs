using ForumApp.Contracts;
using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllAsync();

            return View(posts);
        }

        public async Task<IActionResult> Add()
        => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Invalid post!");
            }

            await _postService.AddPostAsync(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);

            return View(new PostViewModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,PostViewModel model)
        {
            await _postService.EditPostAsync(id, model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeletePostAsync(id);

            return RedirectToAction("Index");
        }
    }
}
