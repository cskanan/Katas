using DigitizerMain.Adapters;
using DigitizerMain.Libraries;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class DigitizerTests
    {
        private IConsole _console;
        private IDigitizer _digitizer;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();

            _digitizer = new Digitizer(_console);
        }

        [Test]
        public void RecieveInputCallsConsoleWriteLine()
        {
            _digitizer.RecieveInput();

            _console.Received().WriteLine($"Please enter digits");
            _console.Received().ReadLine();

        }

        [Test]
        public void PrintDigitizedInputCallsConsoleWriteLine()
        {
            _digitizer.PrintDigitizedInput();

            _console.Received().WriteLine(Arg.Any<string>());
        }


    }


}
