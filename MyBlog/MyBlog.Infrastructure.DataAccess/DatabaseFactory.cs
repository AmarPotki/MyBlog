using MyBlog.Core.Common;

namespace MyBlog.Infrastructure.DataAccess
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DatabaseContext _database;

        public DatabaseContext Get()
        {
            return _database ?? (_database = new DatabaseContext());
        }
        protected override void DisposeCore()
        {
            if (_database != null)
                _database.Dispose();
        }
    }
}
