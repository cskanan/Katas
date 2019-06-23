using System;
using NSubstitute;
using NUnit.Framework;
using PdfToTextService.Services;

namespace Tests.Service
{

    [TestFixture]
    public class SmsServiceTests
    {
        private ISmsService _sms;

        [SetUp]
        public  void Setup()
        {
            _sms = new SmsService();
        }

        [Test]
        public  void SendThrowNotImplementedError()
        {
           Assert.Throws<NotImplementedException>(
               ()=> _sms.Send());
        }
    }
}
