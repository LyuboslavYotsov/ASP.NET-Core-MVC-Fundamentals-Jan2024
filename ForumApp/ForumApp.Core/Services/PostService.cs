using ForumApp.Contracts;
using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models.Post;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Services
{
    public class PostService : IPostService
    {
        private readonly ForumAppDbContext _context;

        public PostService(ForumAppDbContext context)
        {
            _context = context;
        }

        public async Task AddPostAsync(PostViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
            };

            await _context.Posts.AddAsync(post);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);


            if (post == null)
            {
                throw new ArgumentException($"Post with id:{id} does not exist!");
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task EditPostAsync(PostViewModel model)
        {
            var post = await _context.Posts.FindAsync(model.Id);

            if (post == null)
            {
                throw new ArgumentException($"Post with id:{model.Id} does not exist!");
            }

            post.Content = model.Content;
            post.Title = model.Title;

            await _context.SaveChangesAsync();
        }

        public async Task<IList<PostViewModel>> GetAllAsync()
        {
            var posts = await _context.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();

            return posts;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            Post entity = new Post();

            if (post != null)
            {
                entity.Title = post.Title;
                entity.Content = post.Content;
            }
            return entity;
        }
    }
}
