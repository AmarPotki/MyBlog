using MyBlog.Core.Model;
using MyBlog.Core.Repository;

namespace MyBlog.Infrastructure.DataAccess.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
