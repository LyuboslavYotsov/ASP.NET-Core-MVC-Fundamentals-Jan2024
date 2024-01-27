using ForumApp.Data.Models;
using ForumApp.Models.Post;

namespace ForumApp.Contracts
{
    public interface IPostService
    {
        Task<IList<PostViewModel>> GetAllAsync();

        Task AddPostAsync(PostViewModel model);

        Task DeletePostAsync(int id);

        Task<Post> GetPostByIdAsync(int id);

        Task EditPostAsync(int id, PostViewModel model);
    }
}
