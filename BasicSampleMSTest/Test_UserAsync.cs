using BasicSample.Application;
using BasicSample.DbAccess;
using BasicSample.DbAccess.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Entity.Infrastructure;
using TestingDemo;

namespace BasicSampleMSTest
{
    [TestClass]
    public class Test_UserAsync
    {
        [TestMethod]
        public async Task Test_FillingUp()
        {
            var data = new List<User>
            {
                new User { Name = "BBB" },
                new User { Name = "ZZZ" },
                new User { Name = "AAA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();

            mockSet.As<IDbAsyncEnumerable<User>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<User>(data.GetEnumerator()));

            mockSet.As<IQueryable<User>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<User>(data.Provider));

            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var mockContext = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var service = new CarService(mockContext.Object);
            var blogs = await service.GetUserListAsync();

            Assert.AreEqual(3, blogs.Count);
            Assert.AreEqual("AAA", blogs[0].Name);
            Assert.AreEqual("BBB", blogs[1].Name);
            Assert.AreEqual("ZZZ", blogs[2].Name);
        }
    }
}