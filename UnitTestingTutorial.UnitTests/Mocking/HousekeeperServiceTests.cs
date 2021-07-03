using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using UnitTestingTutorial.Mocking;

namespace UnitTestingTutorial.UnitTests.Mocking
{
    [TestFixture]
    public class HousekeeperServiceTests
    {
        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>()
            {
                new Housekeeper {Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c"}
            }.AsQueryable());

            var statementGenerator = new Mock<IStatementGenerator>();
            var emailSender = new Mock<IEmailSender>();
            var messageBox = new Mock<IXtraMessageBox>();

            var serivce = new HousekeeperService(
                unitOfWork.Object,
                statementGenerator.Object,
                emailSender.Object,
                messageBox.Object);
            
            serivce.SendStatementEmails(new DateTime(2017, 1, 1));
            
            statementGenerator.Verify(sg => sg.SaveStatement(1, "b", new DateTime(2017, 1, 1)));
            
        }
    }
}