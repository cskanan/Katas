using System;

namespace PdfToTextService.Adapters
{
    public interface IConsole
    {
        string ReadLine();
        void WriteLine(string value);
    }

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
