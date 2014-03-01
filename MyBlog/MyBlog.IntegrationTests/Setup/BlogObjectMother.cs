using System;
using MyBlog.Core.Model;

namespace MyBlog.IntegrationTests.Setup
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

        public static Post Post()
        {
            return new Post { Title = "This is Post", Description = "this is description", UrlSlug = "first-Post",PostedOn = DateTime.Now,Published = true};
        }
    }
}
