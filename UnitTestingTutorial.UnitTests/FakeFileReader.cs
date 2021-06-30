using UnitTestingTutorial.Mocking;

namespace UnitTestingTutorial.UnitTests
{
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}