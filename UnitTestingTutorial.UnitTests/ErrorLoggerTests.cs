using System;
using NUnit.Framework;
using UnitTestingTutorial.Fundamentals;

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

        [Test]
        public void Log_ValidError_RaiseErrorLogEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };
            
            logger.Log("a");
            
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
        
        // What you shouldn't do:
        // [Test]
        // public void OnErrorLogged_WhenCalled_RaiseEvent()
        // {
        //     var logger = new ErrorLogger();
        //     
        //     logger.OnErrorLogged();
        //     
        //     Assert.That(true);
        // }
    }
}