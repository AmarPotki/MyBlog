using System;

namespace MyBlog.Infrastructure.DataAccess
{
    public interface IDatabaseFactory : IDisposable
    {
        DatabaseContext Get();
    }
}
