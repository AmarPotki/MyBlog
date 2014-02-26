using System.Data.Entity;

namespace MyBlog.Infrastructure.DataAccess
{
    public class DatabaseContextInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {

    }
}
