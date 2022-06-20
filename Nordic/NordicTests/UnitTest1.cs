using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordicCommon;

namespace NordicTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, Calculation.Factorial(0));
            Assert.AreEqual(1, Calculation.Factorial(1));
            Assert.AreEqual(2, Calculation.Factorial(2));
        }

        [DataTestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        public void TestMethod2(int n, int expected)
        {
            Assert.AreEqual(expected, Calculation.Factorial(n));
        }

    }
}
