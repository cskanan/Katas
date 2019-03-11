using DigitizerMain.Libraries;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class PrintableCharBuilderTests
    {
        IDigitBuilder _digitBuilder;

        IPrintableCharBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _digitBuilder 
                = Substitute.For<IDigitBuilder>();

            _builder 
                = new PrintableCharBuilder(
                    _digitBuilder);
        }

        [Test]
        public void BuildCallsDigitBuilder()
        {
            const string Input = "dsfsd";

            (string line1, string line2, string line3) printableData
                = _builder
                    .Build(Input);

            _digitBuilder
                .Received()
                .Build(
                    Input);            
        }

        [Test]
        public void Build()
        {
            (string line1, string line2, string line3) printableData 
                = _builder
                    .Build("0");

            Assert
                .That(
                    printableData.line1, 
                Is.EqualTo(
                    " _ "));
        }
    }
}
