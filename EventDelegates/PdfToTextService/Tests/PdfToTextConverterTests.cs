using System;
using NSubstitute;
using NUnit.Framework;
using PdfToTextService;
using PdfToTextService.Adapters;

namespace Tests
{
    [TestFixture]
    public class PdfToTextConverterTests
    {
        private const string FILE_NAME_PDF = "FileName.pdf";
        private const string  CONVERTED_FILE_NAME= "FileName.txt";

        private IConsole _console;

        private IPdfToTextConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();

            _converter = new PdfToTextConverter(_console);
        }

        [Test]
        public void Convert()
        {
            
            string actual = _converter.Convert(FILE_NAME_PDF);

            
            AssertThat(
                actual, 
                CONVERTED_FILE_NAME);
        }

        [Test]
        public void ConvertCallsConsoleWriteLine()
        {
            _converter.Convert(FILE_NAME_PDF);

            _console.ReceivedWithAnyArgs(2).WriteLine(Arg.Any<string>());
        }

        [Test]
        public void ConvertRaiseEventCompleted()
        {
            bool isEventRaised=false;

            _converter.Completed += delegate
            {
                isEventRaised = true;
            };

            _converter.Convert(
                FILE_NAME_PDF);

            AssertThat(
                isEventRaised, 
                    true);
        }

        [Test]
        public void CompletedEventShowsConvertedFileName()
        {
            string fileName = string.Empty;

            _converter.Completed += (sender, eventArgs) =>
                {
                    fileName = eventArgs.FileName;
                };

            _converter.Convert(
                FILE_NAME_PDF);

            AssertThat(
                fileName, 
                CONVERTED_FILE_NAME);
        }

        private void AssertThat<T>(T actual, T expected)
        {
            Assert.That(
                actual,
                Is.EqualTo(expected));
        }

    }
}
