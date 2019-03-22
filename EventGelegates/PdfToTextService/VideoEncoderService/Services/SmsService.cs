namespace PdfToTextService.Services
{
    public interface ISmsService
    {
        void Send();
    }

    public class SmsService : ISmsService
    {
        public void Send()
        {
            throw new System.NotImplementedException();
        }
    }
}