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
        string _input;
        public Digitizer(IConsole console)
        {
            _console = console;
        }

        public void PrintDigitizedInput()
        {
            _console.WriteLine(_input);
        }

        public void RecieveInput()
        {
            _console.WriteLine("Please enter digits");
            _input = _console.ReadLine();
        }
    }
}
