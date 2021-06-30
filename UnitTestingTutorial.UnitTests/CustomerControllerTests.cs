using NUnit.Framework;
using UnitTestingTutorial.Fundamentals;

namespace UnitTestingTutorial.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            ActionResult result = controller.GetCustomer(0);

            #region Assert NotFound

            Assert.That(result, Is.TypeOf<NotFound>());

            #endregion

            #region Assert NotFound or one if its derivatives

            // Assert.That(result, Is.InstanceOf<NotFound>());

            #endregion
        }
        
        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            //TODO: Write test logic here
        }
    }
}