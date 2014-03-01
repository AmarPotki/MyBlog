using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Core.Model;

namespace MyBlog.Infrastructure.DataAccess.Test.Setup
{
    public static class BlogObjectMother
    {
        public static Tag Tag()
        {
            return new Tag { Description = "asp dot net mvc", Name = "MVC", UrlSlug = "asp-Net-MVC" };
        }
        public static Category Category()
        {
            return new Category { Description = "asp.Net MVC C#", Name = "Asp.Net MVC", UrlSlug = "asp-Net-MVC" };
        }
    }
}
