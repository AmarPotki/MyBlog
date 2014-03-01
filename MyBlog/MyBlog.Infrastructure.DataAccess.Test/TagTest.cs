using Moq;
using MyBlog.Core.Infrastructure;
using MyBlog.Core.Repository;
using MyBlog.Infrastructure.DataAccess.Repositories;
using MyBlog.Infrastructure.DataAccess.Test.Setup;
using Xunit;
using Xunit.Extensions;

namespace MyBlog.Infrastructure.DataAccess.Test
{
    public class TagTest : DatabaseContextBase
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagTest()
        {
            _unitOfWork = new UnitOfWork(DatabaseFactory);
            _tagRepository = new TagRepository(DatabaseFactory);
        }

        [Fact, AutoRollback]
        public void AddTag()
        {
            var tag = BlogObjectMother.Tag();
            var beforCount = _tagRepository.GetCount();
            _tagRepository.Add(tag);
            _unitOfWork.Commit();
            Assert.Equal(beforCount + 1, _tagRepository.GetCount());

        }
    }
}
