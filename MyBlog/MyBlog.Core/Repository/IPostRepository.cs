using System.Collections.Generic;
using MyBlog.Core.Model;

namespace MyBlog.Core.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsByTag(string urlSlug);
        IEnumerable<Post> GetPostsByCategory(int categoryId);
        Post Post(int year, int month, string urlSlug);
        IEnumerable<Post> Posts(int? year, int? month);
        IEnumerable<Post> Posts();
    }
}
