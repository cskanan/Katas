using System;
using Castle.Core.Smtp;
using NSubstitute;
using NUnit.Framework;
using PdfToTextService;
using PdfToTextService.Adapters;
using PdfToTextService.Services;

namespace Tests.Service
{
    [TestFixture]
    public class EmailServiceTests
    {
        private IConsole _console;

        private IEmailService _email;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _email = new EmailService(_console);
        }

        [Test]
        public void SendCallsConsole()
        {
            _email.Send(
                new object(), 
                new EventArgsPdfConverter());

            _console.Received().WriteLine(
                Arg.Any<string>());
        }
    }
}
