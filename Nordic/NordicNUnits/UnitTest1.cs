using NUnit.Framework;
using NordicCommon;

namespace NordicNUnits
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, Calculation.Factorial(0));
            Assert.AreEqual(1, Calculation.Factorial(1));
            Assert.AreEqual(2, Calculation.Factorial(2));
        }

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(4, 24)]
        public void Test2(int n, int expected)
        {
            Assert.AreEqual(expected, Calculation.Factorial(n));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        public void Test3(int n, int expected)
        {
            Assert.That(Calculation.Fibonacci(n), Is.EqualTo(expected));
            // Assert.AreEqual(expected, Calculation.Fibonacci(n));
        }

        [TestCaseSource(typeof (TestData), nameof(TestData.GetData))]
        public void Test4(TestData item)
        {
            Assert.That(Calculation.Fibonacci(item.n), Is.EqualTo(item.expected));
        }
    }
}