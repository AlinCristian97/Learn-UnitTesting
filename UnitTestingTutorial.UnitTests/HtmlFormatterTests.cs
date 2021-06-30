using NUnit.Framework;
using UnitTestingTutorial.Fundamentals;

namespace UnitTestingTutorial.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            string result = formatter.FormatAsBold("abc");

            #region Specific Assertion

            // Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            #endregion

            #region More general Assertion

            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain("abc").IgnoreCase);

            #endregion
        }
        
    }
}