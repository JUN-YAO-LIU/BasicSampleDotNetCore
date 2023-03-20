using BasicSample.Application;

namespace BasicSampleMSTest
{
    [TestClass]
    public class Test_Car
    {
        private readonly ICarService _carTest;

        public Test_Car()
        {
            _carTest = new CarService();
        }

        [TestMethod]
        public void Test_FillingUp()
        {
            string result = _carTest.FillingUp();
            Assert.IsNotNull(result, "1 should not be null.");
        }
    }
}