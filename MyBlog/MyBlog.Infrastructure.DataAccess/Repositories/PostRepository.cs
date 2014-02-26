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
    }
}
