using System.Threading;
using PdfToTextService.Adapters;
using PdfToTextService.Services;

namespace PdfToTextService
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IConsole console = 
                new ConsoleAdapter();
            IPdfToTextConverter pdfToText = 
                new PdfToTextConverter(new ConsoleAdapter());
            IEmailService email = 
                new EmailService(new ConsoleAdapter());

            pdfToText.Completed += email.Send;

            pdfToText.Convert("TDDEvent.pdf");
            console.ReadLine();
        }
    }
}
