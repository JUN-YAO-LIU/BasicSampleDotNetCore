using BasicSample.Application;
using BasicSample.DbAccess;
using BasicSample.DbAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace BasicSampleMSTest
{
    [TestClass]
    public class Test_User
    {
        [TestMethod]
        public void Test_FillingUp()
        {
            var data = new List<User>
            {
                new User { Name = "BBB" },
                new User { Name = "ZZZ" },
                new User { Name = "AAA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new CarService(mockContext.Object);
            var result = service.GetUserList();

            //Assert
            Assert.IsNotNull(result, "1 should not be null.");
        }
    }
}