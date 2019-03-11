using DigitizerMain.Adapters;
using DigitizerMain.Libraries;

namespace DigitizerMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Digitizer digitizer = new 
                Digitizer(
                    new ConsoleAdapter(),
                    new PrintableCharBuilder(
                        new DigitBuilder()));

            digitizer
                .RecieveInput();

            digitizer
                .PrintDigitizedInput();
        }
    }
}
