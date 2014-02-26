using MyBlog.Core.Model;
using MyBlog.Core.Repository;

namespace MyBlog.Infrastructure.DataAccess.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
