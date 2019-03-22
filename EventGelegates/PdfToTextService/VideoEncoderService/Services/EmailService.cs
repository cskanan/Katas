using PdfToTextService.Adapters;

namespace PdfToTextService.Services
{
    public interface IEmailService
    {
        void Send(
            object obj, 
            EventArgsPdfConverter eventArgsPdfConverter);
    }
    public class EmailService : IEmailService
    {
        private readonly IConsole _console;

        public EmailService(
            IConsole console)
        {
            _console = console;
        }

        public void Send(
            object obj, 
            EventArgsPdfConverter eventArgsPdfConverter)
        {
            _console.WriteLine(
                $"Hi, document has been converted into text. The file name is {eventArgsPdfConverter.FileName}");
        }
    }
}