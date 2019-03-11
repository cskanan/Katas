using DigitizerMain.Libraries;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTests
{
    [TestFixture]
    public class DigitBuilderTests
    {
        private const string NUMBER_TO_BE_DIGITIZED = "123";
        IDigitBuilder _digitBuilder;

        [SetUp]
        public void Setup()
        {
            _digitBuilder = new DigitBuilder();
        }

        [Test]
        public void Build()
        {
            List<Digit> actual
                = _digitBuilder
                    .Build(
                        NUMBER_TO_BE_DIGITIZED);

            Assert
                .That(
                    actual
                        .Count,
                Is
                    .EqualTo(3));
        }

        [Test]
        public void BuildReturnsPrintableDigits()
        {
            List<Digit> expected = 
                    GetDigitalRepresntationOf123();

            List<Digit> actual = 
                    _digitBuilder
                        .Build(
                            NUMBER_TO_BE_DIGITIZED);

            AssertProperties(actual, expected);
        }
                
        [TestCase("lol1")]
        [TestCase(" ")]
        [TestCase("--")]
        [TestCase("")]
        [TestCase("12331fdsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")]
        public void BuildReturnErrWhenNonNumbericValueEntered(string input)
        {
            List<Digit> expected = 
                    GetDigitalRepresentationOfErr();

            List<Digit> actual = 
                    _digitBuilder
                        .Build(input);

            AssertProperties(
                actual, 
                expected);
        }

        private static List<Digit> GetDigitalRepresentationOfErr()
        {
            return new List<Digit> {
            new Digit
            {
                TopRight= false,
                BottomRight= false
            },
            new Digit
            {
                Top= false,
                TopLeft= false,
                TopRight= false,
                BottomRight = false,
                Bottom = false
            },
            new Digit
            {
               TopLeft= false,
                BottomLeft= false
            },
            };
        }

        private static List<Digit> GetDigitalRepresntationOf123()
        {
            return new List<Digit> {
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
        }


        private void AssertProperties(
            List<Digit> actual, 
            List<Digit> expected)
        {

            for (int i = 0; i < actual.Count; i++)
            {
                /*
                --This is how I asserted the properties first few times. When I have to assert more and more properties, 
                I started using reflextion. Please comment if you  have better way 

                Assert.That(actual[i].Top, Is.EqualTo(expected[i].Top));
                Assert.That(actual[i].TopLeft, Is.EqualTo(expected[i].TopLeft));
                Assert.That(actual[i].TopRight, Is.EqualTo(expected[i].TopRight));
                Assert.That(actual[i].Middle, Is.EqualTo(expected[i].Middle));
                Assert.That(actual[i].BottomLeft, Is.EqualTo(expected[i].BottomLeft));
                Assert.That(actual[i].BottomRight, Is.EqualTo(expected[i].BottomRight));
                Assert.That(actual[i].Bottom, Is.EqualTo(expected[i].Bottom));
                */

                AssertProperty(
                    actual[i], 
                    expected[i]);

            }
        }

        private void AssertProperty(
            Digit actual,
            Digit expected)
        {
            PropertyInfo[] properties
                = actual
                    .GetType()
                    .GetProperties();

            foreach (var property in properties)
            {
                Assert
                    .That(
                        GetPropertyValue(
                            actual,
                            property),
                    Is
                    .EqualTo(
                        GetPropertyValue(
                            expected,
                            property)));
            }
        }

        private static bool GetPropertyValue(
            Digit obj,
            PropertyInfo property)
        {
            var restult = (bool)obj
                            .GetType()
                            .GetProperty(
                                property.Name
                                    .ToString())
                            .GetValue(obj, null);

            return (bool)obj
                            .GetType()
                            .GetProperty(
                                property.Name
                                    .ToString())
                            .GetValue(obj);
        }
    }
}
