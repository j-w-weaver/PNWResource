namespace PNWResource.API.Services
{
    public class CloudMailService : IMailService
    {
        private string mail_To = string.Empty;
        private string mail_From = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
            mail_To = configuration["mailSettings:mailToEmail"]!;
            mail_From = configuration["mailSettings:mailFromEmail"]!;
        }

        public void SendMail(string subject, string message)
        {
            // send mail
            Console.WriteLine($"Mail from {mail_To} to {mail_From}, with {nameof(CloudMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
