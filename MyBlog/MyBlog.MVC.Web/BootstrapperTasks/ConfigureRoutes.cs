using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyBlog.Core.Infrastructure.Logging;

namespace MyBlog.MVC.Web.BootstrapperTasks
{
    public class ConfigureRoutes : IBootstrapTask
    {
        public void Execute()
        {
            RegisterRoutes(RouteTable.Routes);
           LogUtility.Log.Info("Configuring Routes.");
        }

        public int Priority
        {
            get { return 5; }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*allaspx}", new { allaspx = @".*\.aspx(/.*)?" });
            routes.IgnoreRoute("{*allhtml}", new { allhtml = @".*\.html(/.*)?" });
            routes.IgnoreRoute("{*allpng}", new { allpng = @".*\.png(/.*)?" });
            routes.IgnoreRoute("{*alljpg}", new { alljpg = @".*\.jpg(/.*)?" });
            routes.IgnoreRoute("{*allgif}", new { allgif = @".*\.gif(/.*)?" });
            routes.IgnoreRoute("{*allico}", new { allico = @".*\.ico(/.*)?" });
            //THIS IS FOR THE ROOT OF THE SITE IF THE ROOT IS NOT A TEMPLATE PAGE


            routes.MapRoute(
         "Default", // Route name
         "{controller}/{action}/{id}", // URL with parameters
         new { controller = "Home", action = "Index", id = UrlParameter.Optional },
         new[] { "MyBlog.MVC.Web.Controllers" }
     );



        }
    }
}