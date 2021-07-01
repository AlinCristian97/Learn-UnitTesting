using Moq;
using NUnit.Framework;
using UnitTestingTutorial.Mocking;

namespace UnitTestingTutorial.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        // 
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            controller.DeleteEmployee(1);
            
            storage.Verify(s => s.DeleteEmployeeFromDb(1));
        }
    }
}