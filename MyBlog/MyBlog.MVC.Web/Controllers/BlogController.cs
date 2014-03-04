using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Core.Repository;

namespace MyBlog.MVC.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostRepository _postRepository;

        public BlogController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Post(int year, int month, string title)
        {
            var post = _postRepository.Post(year, month, title);

            if (post == null)
                throw new HttpException(404, "Post not found");

            if (post.Published == false && User.Identity.IsAuthenticated == false)
                throw new HttpException(401, "The post is not published");

            return View(post);
        }

        public  ActionResult Tag(string tag)
        {
            var posts = _postRepository.GetPostsByTag(tag);
            return View();
        }


    }
}
