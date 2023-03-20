using BasicSample.Application;
using BasicSample.DbAccess;
using Moq;

namespace BasicSampleMSTest
{
    [TestClass]
    public class Test_Car
    {
        [TestMethod]
        public void Test_FillingUp()
        {
            var mockContext = new Mock<ApplicationDbContext>();
            var car = new CarService(mockContext.Object);
            string result = car.FillingUp();
            Assert.IsNotNull(result, "1 should not be null.");
        }
    }
}