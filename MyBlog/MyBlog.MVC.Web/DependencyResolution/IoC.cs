using System.Web;
using MyBlog.Core.Infrastructure;
using MyBlog.Core.Infrastructure.Logging;
using MyBlog.Core.Repository;
using MyBlog.Infrastructure.DataAccess;
using MyBlog.Infrastructure.DataAccess.Repositories;
using MyBlog.MVC.Web.BootstrapperTasks;
using StructureMap;

namespace MyBlog.MVC.Web.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Configure(x =>
            {
                x.Scan(scan =>
                {
                    scan.LookForRegistries();
                    scan.Assembly("MyBlog.MVC.Web");
                    scan.Assembly("MyBlog.Core");
                    //scan.AssemblyContainingType<IImageManager>();
                    scan.AddAllTypesOf<IBootstrapTask>();
                    scan.AddAllTypesOf<ILogger>();
                    scan.WithDefaultConventions();

                });
                x.For<IUnitOfWork>().HttpContextScoped().Use<UnitOfWork>();
                x.For<IDatabaseFactory>().HttpContextScoped().Use<DatabaseFactory>();


                x.For<HttpContext>().Use(() => HttpContext.Current);
                x.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));

                x.For<ITagRepository>().HttpContextScoped().Use<TagRepository>();
                x.For<ICategoryRepository>().HttpContextScoped().Use<CategoryRepository>();
                x.For<IPostRepository>().HttpContextScoped().Use<PostRepository>();


            });

            return ObjectFactory.Container;
        }
    }
}