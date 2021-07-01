using Moq;
using NUnit.Framework;
using UnitTestingTutorial.Mocking;

namespace UnitTestingTutorial.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            var product = new Product() {ListPrice = 100};

            float result = product.GetPrice(new Customer {IsGold = true});
            
            Assert.That(result, Is.EqualTo(70));
        }
        
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscountMockAbuse()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);
            
            var product = new Product() {ListPrice = 100};

            float result = product.GetPrice(customer.Object);
                
            Assert.That(result, Is.EqualTo(70));
        }
    }
}