using System.Linq;
using System.Web.Mvc;
using MyBlog.MVC.Web.DependencyResolution;
using StructureMap;

namespace MyBlog.MVC.Web.BootstrapperTasks
{
    public static class Bootstrapper
    {
        static Bootstrapper()
        {
            var container = (IContainer)IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }

        public static void Initialize()
        {
            var items = ObjectFactory.GetAllInstances<IBootstrapTask>();
            foreach (var bootstrapTask in items.OrderByDescending(x => x.Priority))
            {
                bootstrapTask.Execute();
            }
        }
    }
}