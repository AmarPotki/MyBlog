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
        public ViewResult Posts(int? year, int? month)
        {


            return View(_postRepository.Posts(year, month));
        }
        public ViewResult Post(int year, int month, string urlSlug)
        {


            var post = _postRepository.Post(year, month, urlSlug);

            if (post == null)
            {
                throw new HttpException(404, "Post not found");

            }
            // in core  must handle   
            //if (post.Published == false && User.Identity.IsAuthenticated == false)
              //  throw new HttpException(401, "The post is not published");

            return View(post);
        }

        public ActionResult Tag(string tag)
        {
            var posts = _postRepository.GetPostsByTag(tag);
            return View();
        }


    }
}
