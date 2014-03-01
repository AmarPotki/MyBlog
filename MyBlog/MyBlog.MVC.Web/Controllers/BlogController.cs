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

        public  ActionResult Tag(string tag)
        {
            var posts = _postRepository.GetPostsByTag(tag);
            return View();
        }


    }
}
