using System.Web.Mvc;
using MyBlog.Core.Infrastructure.Logging;

namespace MyBlog.MVC.Web.BootstrapperTasks
{
    public class ConfigureAreas : IBootstrapTask
    {
        public void Execute()
        {
            AreaRegistration.RegisterAllAreas();

            LogUtility.Log.Info("Configuring Areas.");
        }

        public int Priority
        {
            get { return 10; }
        }
    }
}