using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace UnitTestingTutorial.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetLastErrorProperty()
        {
            var logger = new ErrorLogger();
            
            logger.Log("a");
            
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            //TODO: Move logger initialization in the NUnit SetUp method
            var logger = new ErrorLogger();
            
            // Instead of this:
            // logger.Log(error);
            
            // We use a delegate / lambda expression in the Assertion
            // Shorter syntax:
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            
            // Longer syntax:
            // Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}