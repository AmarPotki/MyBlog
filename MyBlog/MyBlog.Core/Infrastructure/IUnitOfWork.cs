namespace MyBlog.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
