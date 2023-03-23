using BasicSample.Application;
using BasicSample.DbAccess;
using BasicSample.DbAccess.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Entity.Infrastructure;

namespace BasicSampleMSTest
{
    [TestClass]
    public class Test_User
    {
        [TestMethod]
        public void Test_Select()
        {
            var data = new List<User>
            {
                new User { Name = "AAA" },
                new User { Name = "BBB" },
                new User { Name = "ZZZ" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();

            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var mockContext = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var service = new CarService(mockContext.Object);
            var blogs = service.GetUserList();

            Assert.AreEqual(3, blogs.Count);
            Assert.AreEqual("AAA", blogs[0].Name);
            Assert.AreEqual("BBB", blogs[1].Name);
            Assert.AreEqual("ZZZ", blogs[2].Name);
        }

        [TestMethod]
        public void Test_Insert()
        {
            var mockSet = new Mock<DbSet<User>>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var mockContext = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new CarService(mockContext.Object);
            service.CreateUser("Jim");

            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}