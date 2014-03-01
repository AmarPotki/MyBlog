using System.Collections.Generic;
using System.Linq;
using MyBlog.Core.Infrastructure;
using MyBlog.Core.Model;
using MyBlog.Core.Repository;
using MyBlog.Infrastructure.DataAccess;
using MyBlog.Infrastructure.DataAccess.Repositories;
using MyBlog.IntegrationTests.Setup;
using Xunit;
using Xunit.Extensions;

namespace MyBlog.IntegrationTests
{
    public class PostTest : DatabaseContextBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITagRepository _tagRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;

        public PostTest()
        {
            _postRepository = new PostRepository(DatabaseFactory);
            _categoryRepository = new CategoryRepository(DatabaseFactory);
            _tagRepository = new TagRepository(DatabaseFactory);
            _unitOfWork = new UnitOfWork(DatabaseFactory);
        }

        [Fact, AutoRollback]
        public void AddPostWithoutTagAndCategory()
        {
            var post = BlogObjectMother.Post();
            var beforCount = _postRepository.GetCount();
            _postRepository.Add(post);
            _unitOfWork.Commit();
            Assert.Equal(beforCount + 1, _postRepository.GetCount());
            var newPost = _postRepository.ById(post.Id);
            Assert.Equal(newPost.UrlSlug, "first-Post");

        }
        [Fact, AutoRollback]
        public void AddPostByTagAndCategory()
        {
            var tag = BlogObjectMother.Tag();
            _tagRepository.Add(tag);

            var category = BlogObjectMother.Category();
            _categoryRepository.Add(category);
            _unitOfWork.Commit();

            var post = BlogObjectMother.Post();
            var beforCount = _postRepository.GetCount();
            var newTag = _tagRepository.ById(tag.Id);
            var newCategory = _categoryRepository.ById(category.Id);
            post.Tags.Add(newTag);
            post.Category = newCategory;
            _postRepository.Add(post);
            _unitOfWork.Commit();
            Assert.Equal(beforCount + 1, _postRepository.GetCount());
            var newPost = _postRepository.ById(post.Id);
            Assert.NotNull(newPost.Category);


        }


        [Fact, AutoRollback]
        public void FectchPostsThatHaveASpecificTag()
        {
            var tag = BlogObjectMother.Tag();
            _tagRepository.Add(tag);

            var category = BlogObjectMother.Category();
            _categoryRepository.Add(category);
            _unitOfWork.Commit();

            var post = BlogObjectMother.Post();
            var newTag = _tagRepository.ById(tag.Id);
            var newCategory = _categoryRepository.ById(category.Id);
            post.Tags.Add(newTag);
            post.Category = newCategory;
            _postRepository.Add(post);
            _unitOfWork.Commit();
            var posts = _postRepository.GetPostsByTag(newTag.UrlSlug).ToList();
            Assert.NotNull(posts);
            Assert.NotEqual(posts.Count, 0);
            Assert.True(posts.Any());
        }

        [Fact, AutoRollback]
        public void FecthPostsWithCategory()
        {

            var tag = BlogObjectMother.Tag();
            _tagRepository.Add(tag);

            var category = BlogObjectMother.Category();
            _categoryRepository.Add(category);
            _unitOfWork.Commit();

            var post = BlogObjectMother.Post();
            var beforCount = _postRepository.GetCount();
            var newTag = _tagRepository.ById(tag.Id);
            var newCategory = _categoryRepository.ById(category.Id);
            post.Tags.Add(newTag);
            post.Category = newCategory;
            _postRepository.Add(post);
            _unitOfWork.Commit();
            var posts = _postRepository.GetPostsByCategory(category.Id);
            Assert.NotNull(posts);
            Assert.NotNull(posts.First().Tags);
            Assert.Equal(posts.First().Tags.First().Name, "MVC");
        }

        [Fact]
        public void AddPostByTagAndCategoryTestRealInsert()
        {


            var post = BlogObjectMother.Post();
            var beforCount = _postRepository.GetCount();
            var newTag = _tagRepository.ById(1);
            var newCategory = _categoryRepository.ById(13);
            post.Tags.Add(newTag);
            post.Category = newCategory;
            _postRepository.Add(post);
            _unitOfWork.Commit();
            Assert.Equal(beforCount + 1, _postRepository.GetCount());
            var newPost = _postRepository.ById(post.Id);
            Assert.NotNull(newPost.Category);


        }

        [Fact, AutoRollback]
        public void FecthPostsWithCategoryReal()
        {



            var posts = _postRepository.GetPostsByCategory(13);
            Assert.NotNull(posts);
            Assert.NotNull(posts.First().Tags);
            Assert.Equal(posts.First().Tags.First().Name, "MVC");
        }
    }
}
