namespace PNWResource.API.Services
{
    public class CloudMailService : IMailService
    {
        private string mail_To = "admin@pnwresource.com";
        private string mail_From = "noreply@pnwresource.com";

        public void SendMail(string subject, string message)
        {
            // send mail
            Console.WriteLine($"Mail from {mail_To} to {mail_From}, with {nameof(CloudMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
