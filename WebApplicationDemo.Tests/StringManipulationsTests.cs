using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationDemo.Services;

namespace WebApplicationDemo.Tests
{
    [TestClass]
    public class StringManipulationsTests
    {
        [TestMethod]
        public void TestValidMail()
        {
            var stringManipulations = new StringManipulations();

            var result = stringManipulations.CheckIfStringIsMail("user@domain.de");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestInvalidEmail()
        {
            var stringManipulations = new StringManipulations();

            var result = stringManipulations.CheckIfStringIsMail("sdjkfhsdkjhfhsdkjfh");

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNULLInput()
        {
            var stringManipulations = new StringManipulations();

            stringManipulations.CheckIfStringIsMail(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyInput()
        {
            var stringManipulations = new StringManipulations();

            stringManipulations.CheckIfStringIsMail(String.Empty);
        }
    }
}
