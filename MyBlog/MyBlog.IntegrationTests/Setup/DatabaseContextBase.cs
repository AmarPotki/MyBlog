
using MyBlog.Core.Infrastructure;
using MyBlog.Infrastructure.DataAccess;
using MyBlog.MVC.Web.DependencyResolution;
using System.Web.Mvc;

namespace MyBlog.IntegrationTests.Setup
{
    public class DatabaseContextBase
    {
        protected IDatabaseFactory DatabaseFactory;
        protected readonly IUnitOfWork UnitOfWork;

        public DatabaseContextBase()
        {
            DatabaseFactory = new DatabaseFactory();
            UnitOfWork = new UnitOfWork(DatabaseFactory);
            var container = IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}
