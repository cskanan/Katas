using System;

namespace DigitizerMain.Adapters
{
    public class ConsoleAdapter : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
