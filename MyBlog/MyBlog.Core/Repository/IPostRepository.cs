﻿using System.Collections.Generic;
using MyBlog.Core.Model;

namespace MyBlog.Core.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsByTag(string urlSlug);
        IEnumerable<Post> GetPostsByCategory(int categoryId);
    }
}
