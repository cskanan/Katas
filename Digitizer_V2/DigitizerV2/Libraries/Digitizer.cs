using DigitizerMain.Adapters;

namespace DigitizerMain.Libraries
{
    public interface IDigitizer
    {
        void RecieveInput();
        void PrintDigitizedInput();
    }
    public class Digitizer : IDigitizer
    {
        private IConsole _console;
        private string _input;
        private IPrintableCharBuilder _printableCharBuilder;
        public Digitizer(
            IConsole console, 
            IPrintableCharBuilder printableCharBuilder)
        {
            _console =
                console;
            _printableCharBuilder =
                printableCharBuilder;
        }

        public void PrintDigitizedInput()
        {
            (string line1, string line2, string line3) printableText =
                _printableCharBuilder
                    .Build(
                        _input);

            WriteLine(
                    printableText
                        .line1);
            WriteLine(
                    printableText
                        .line2);
            WriteLine(
                    printableText
                        .line3);

            _console
                .ReadLine();
        }

        private void WriteLine(
            string output)
        {
            _console
                .WriteLine(
                    output);
        }

        public void RecieveInput()
        {
            WriteLine(
                "Please enter digits");
            _input =
                _console
                    .ReadLine();
        }
    }
}
