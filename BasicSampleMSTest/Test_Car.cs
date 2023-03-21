using BasicSample.Application;
using BasicSample.DbAccess;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BasicSampleMSTest
{
    [TestClass]
    public class Test_Car
    {
        [TestMethod]
        public void Test_FillingUp()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var mockContext = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            var car = new CarService(mockContext.Object);
            string result = car.FillingUp();
            Assert.IsNotNull(result, "1 should not be null.");
        }
    }
}