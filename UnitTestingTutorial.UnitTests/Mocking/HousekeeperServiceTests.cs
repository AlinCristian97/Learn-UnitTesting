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
        private HousekeeperService _service;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private readonly DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _houseKeeper;

        [SetUp]
        public void SetUp()
        {
            _houseKeeper = new Housekeeper {Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c"};

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>()
            {
                _houseKeeper
            }.AsQueryable());

            _statementGenerator = new Mock<IStatementGenerator>();
            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();

            _service = new HousekeeperService(
                unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object);
        }
        
        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            _service.SendStatementEmails(_statementDate);
            
            _statementGenerator.Verify(
                sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate));
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void SendStatementEmails_HouseKeeperEmailIsNullOrEmptyOrWhiteSpace_ShouldNotGenerateStatement(string email)
        {
            _houseKeeper.Email = email;
            
            _service.SendStatementEmails(_statementDate);
            
            _statementGenerator.Verify(
                sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate),
                Times.Never);
        }
    }
}