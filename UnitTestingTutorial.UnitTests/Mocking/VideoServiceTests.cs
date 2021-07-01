using NUnit.Framework;
using UnitTestingTutorial.Mocking;

namespace UnitTestingTutorial.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            var service = new VideoService();
            
            string result = service.ReadVideoTitle(new FakeFileReader());
            
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}