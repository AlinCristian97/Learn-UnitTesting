using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace UnitTestingTutorial.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        [Ignore("Temporary ignored because I need to do something else")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            int result = _math.Add(1, 2);
            
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {
            int result = _math.Max(a, b);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            IEnumerable<int> result = _math.GetOddNumbers(5);

            #region Most general Assertion

            Assert.That(result, Is.Not.Empty);

            #endregion

            #region More general Assertion

            Assert.That(result.Count(), Is.EqualTo(3));

            #endregion

            #region More specific Assertion

            // Assert.That(result, Does.Contain(1));
            // Assert.That(result, Does.Contain(3));
            // Assert.That(result, Does.Contain(5));
            
            // Shorter way to write the above 3 lines:
            Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5}));

            #endregion

            #region Other useful Assertions

            Assert.That(result, Is.Ordered);

            Assert.That(result, Is.Unique);
            
            #endregion
        }
    }
}