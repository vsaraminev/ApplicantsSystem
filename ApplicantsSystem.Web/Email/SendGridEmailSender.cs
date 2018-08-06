namespace ApplicantsSystem.Web.Email
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks;

    public class SendGridEmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("admin@mysite.com", "Applicants System Admin");
            var to = new EmailAddress(email, email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
