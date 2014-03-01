using System.Collections.Generic;
using System.Linq;
using MyBlog.Core.Model;
using MyBlog.Core.Repository;

namespace MyBlog.Infrastructure.DataAccess.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<Post> GetPostsByTag(string urlSlug)
        {
            return Database.Posts.Where(post => post.Tags.All(tg => tg.UrlSlug == urlSlug));
        }

        public IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            //return Database.Posts.Include("Tags").Where(x => x.Category.Id == categoryId);
            return Database.Posts.Where(x => x.Category.Id == categoryId);
        }
    }
}
