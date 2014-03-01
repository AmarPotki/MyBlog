using MyBlog.Core.Infrastructure;
using MyBlog.Core.Repository;
using MyBlog.Infrastructure.DataAccess;
using MyBlog.Infrastructure.DataAccess.Repositories;
using MyBlog.IntegrationTests.Setup;
using Xunit;
using Xunit.Extensions;

namespace MyBlog.IntegrationTests
{
    public class CategoryTest : DatabaseContextBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryTest()
        {
            _categoryRepository = new CategoryRepository(DatabaseFactory);
            _unitOfWork = new UnitOfWork(DatabaseFactory);

        }

        [Fact, AutoRollback]
        public void AddCategory()
        {

            var category = BlogObjectMother.Category();
            var beforCount = _categoryRepository.GetCount();
            _categoryRepository.Add(category);
            _unitOfWork.Commit();
            Assert.Equal(beforCount + 1, _categoryRepository.GetCount());
            var newCategory = _categoryRepository.ById(category.Id);
            Assert.Equal(newCategory.Name, "Asp.Net MVC");
        }
    
    }
}
