﻿using System;
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
        private readonly string _statementFileName = "filename";

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
        
        [Test]
        public void SendStatementEmails_HasGeneratedStatement_EmailTheStatement()
        {
            _statementGenerator
                .Setup(sg => 
                    sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns(_statementFileName);
            
            _service.SendStatementEmails(_statementDate);
            
            _emailSender.Verify(es => 
                es.EmailFile(
                    _houseKeeper.Email,
                    _houseKeeper.StatementEmailBody,
                    _statementFileName,
                    It.IsAny<string>()));
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_StatementFileNameIsNullOrEmptyOrWhiteSpace_ShouldNotEmailTheStatement(string fileName)
        {
            _statementGenerator
                .Setup(sg => 
                    sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns(() => fileName);
            
            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es =>
                    es.EmailFile(
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<string>()),
                Times.Never());
        }

        // [Test]
        // public void SendStatementEmails_EmailSendingFails_DisplayMessageBox()
        // {
        //     _emailSender.Setup(es => es.EmailFile(
        //         It.IsAny<string>(),
        //         It.IsAny<string>(),
        //         It.IsAny<string>(),
        //         It.IsAny<string>())).Throws<Exception>();
        //
        //     _service.SendStatementEmails(_statementDate);
        //
        //     _messageBox.Verify(mb
        //         => mb.Show(It.IsAny<string>(), It.IsAny<string>(),
        //             MessageBoxButtons.OK));
        // }
    }
}