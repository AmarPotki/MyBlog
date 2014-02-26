using System.Data.Entity;
using MyBlog.Infrastructure.DataAccess;

namespace MyBlog.MVC.Web.BootstrapperTasks
{
    public class ConfigureDatabaseInitializer : IBootstrapTask
    {
        public void Execute()
        {
#if (DEBUG)
            Database.SetInitializer(new DatabaseContextInitializer());
#endif
        }

        public int Priority
        {
            get { return 5; }
        }
    }
}