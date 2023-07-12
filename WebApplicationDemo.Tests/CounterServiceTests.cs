using WebApplicationDemo.Services;

namespace WebApplicationDemo.Tests
{
    [TestClass]
    public class CounterServiceTests
    {
        [TestMethod]
        public void TestIncrement()
        {
            var counterService = new CounterService();

            counterService.Increment();
            var counter = counterService.GetCounter();

            Assert.AreEqual(1, counter);
        }

        [TestMethod]
        public void TestGetCounter()
        {
            var counterService = new CounterService();

            var counter = counterService.GetCounter();

            Assert.AreEqual(0, counter);
        }
    }
}