using NUnit.Framework;
using TestNinja.Fundamentals;

namespace UnitTestingTutorial.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var math = new Math();
            
            int result = math.Add(1, 2);
            
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnFirstArgument()
        {
            var math = new Math();

            int result = math.Max(2, 1);
            
            Assert.That(result, Is.EqualTo(2));
        }
        
        [Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            var math = new Math();

            int result = math.Max(1, 2);
            
            Assert.That(result, Is.EqualTo(2));
        }
        
        [Test]
        public void Max_ArgumentsAreEqual_ReturnSameArgument()
        {
            var math = new Math();

            int result = math.Max(1, 1);
            
            Assert.That(result, Is.EqualTo(1));
        }
    }
}