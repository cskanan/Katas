using System;
using System.Threading;
using PdfToTextService.Adapters;

namespace PdfToTextService
{

    public interface IPdfToTextConverter
    {
        string Convert(string filename);
        event EventHandler<EventArgsPdfConverter> Completed;
    }
    public class PdfToTextConverter : IPdfToTextConverter
    {
        private readonly IConsole _console;

        public PdfToTextConverter(IConsole console)
        {
            _console = console;
        }

        public string Convert(string filename)
        {
            _console.WriteLine(
                "Process to convert pdf to txt is started...");

            string textFile =  
                filename.Replace(
                    ".pdf",
                    ".txt") ;
            Thread.Sleep(
                3000);

            _console.WriteLine(
                "Process is finished");
            OnCompleted(
                this, 
                new EventArgsPdfConverter
                {
                    FileName = textFile,
                    Location = "HardDrive"
                });

            return textFile;
        }

        public event EventHandler<EventArgsPdfConverter> Completed;

        protected virtual void OnCompleted(
            object sender, 
            EventArgsPdfConverter args)
        {
            //            if (Completed != null)
            //            {
            //                Completed(sender, args);
            //            } --You can do either way

            Completed?.Invoke(sender, args);
        }
    }
    public class EventArgsPdfConverter
    {
        public string FileName { get; set; }
        public string Location { get; set; }
    }
}