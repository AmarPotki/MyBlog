using System.ComponentModel;
using System.Web.Mvc;
using MyBlog.Core.Infrastructure;
using MyBlog.MVC.Web.DependencyResolution;
using StructureMap;

namespace MyBlog.Infrastructure.DataAccess.Test.Setup
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
