using NUnit.Framework;
using UnitTestingTutorial.Fundamentals;

namespace UnitTestingTutorial.UnitTests
{
    [TestFixture]
    public class FizzBussTests
    {
        [Test]
        public void GetOutput_InputDivisibleBy3And5_ReturnFizzBuzz()
        {
            string result = FizzBuzz.GetOutput(15);
            
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
        
        [Test]
        public void GetOutput_InputDivisibleBy3Only_ReturnFizz()
        {
            string result = FizzBuzz.GetOutput(3);
            
            Assert.That(result, Is.EqualTo("Fizz"));
        }
        
        [Test]
        public void GetOutput_InputDivisibleBy5Only_ReturnBuzz()
        {
            string result = FizzBuzz.GetOutput(5);
            
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputNotDivisibleBy3Or5_ReturnInput()
        {
            string result = FizzBuzz.GetOutput(4);
            
            Assert.That(result, Is.EqualTo(4.ToString()));
        }
        
        
    }
}