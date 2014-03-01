using MyBlog.Core.Model;

namespace MyBlog.Core.Repository
{
    public interface ITagRepository : IRepository<Tag>
    {
        Tag GetTag(string tag);
    }
}
