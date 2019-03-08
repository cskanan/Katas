using DigitizerMain.Libraries;
using NUnit.Framework;
using System.Collections.Generic;


namespace UnitTests
{
    [TestFixture]
    public class DigitBuilderTests
    {
        IDigitBuilder _digitBuilder;

        [SetUp]
        public void Setup()
        {
            _digitBuilder = new DigitBuilder();
        }

        [Test]
        public void Build()
        {
            List<Digit> actual = _digitBuilder.Build("123");

            Assert.That(actual.Count, Is.EqualTo(4));
        }

        [Test]
        public void BuildReturnsPrintableDigits()
        {
            List<Digit> expected = new List<Digit> {
            new Digit
            {
                Top= false,
                Middle=false,
                Bottom=false,
                TopLeft= false,
                BottomLeft= false
            },
            new Digit
            {
                TopLeft= false,
                BottomRight= false
            },
            new Digit
            {
               TopLeft= false,
                BottomLeft= false
            },


            };

            List<Digit> actual = _digitBuilder.Build("123");

            AssertProperties(actual, expected);
        }

        private void AssertProperties(List<Digit> actual, List<Digit> expected)
        {
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.That(actual[i].Top, Is.EqualTo(expected[i].Top));
                Assert.That(actual[i].TopLeft, Is.EqualTo(expected[i].TopLeft));
                Assert.That(actual[i].TopRight, Is.EqualTo(expected[i].TopRight));
                Assert.That(actual[i].Middle, Is.EqualTo(expected[i].Middle));
                Assert.That(actual[i].BottomLeft, Is.EqualTo(expected[i].BottomLeft));
                Assert.That(actual[i].BottomRight, Is.EqualTo(expected[i].BottomRight));
                Assert.That(actual[i].Bottom, Is.EqualTo(expected[i].Bottom));
            }
        }
    }
}
