using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Core.Model;

namespace MyBlog.MVC.Web.Helpers
{
    public static class TitleWithSlugUrlExtensions
    {
        public static string TitleWithSlugUrl(this HtmlHelper htmlHelper, Post post)
        {
            return String.Format("<a href=\"/Blog/Archive/{0}/{1}/{2}\" >{3}</a>", post.PostedOn.Year, post.PostedOn.Month, post.UrlSlug, post.Title);

        }
    }
}