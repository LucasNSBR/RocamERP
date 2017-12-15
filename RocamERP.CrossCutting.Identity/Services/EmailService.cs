using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RocamERP.CrossCutting.Identity.Services
{
    public class IdentityEmailService : IIdentityMessageService
    {
        private IdentityEmailService()
        {
        }

        public static IdentityEmailService Create()
        {
            return new IdentityEmailService();
        }

        public async Task SendAsync(IdentityMessage message)
        {
            string messageSender = "lucaspereirans2017@gmail.com";
            string messageDestination = message.Destination;
            string messageSubject = message.Subject;
            string messageBody = message.Body;

            MailMessage mail = new MailMessage(messageSender, messageDestination, messageSubject, messageBody);

            using (SmtpClient smtpClient = new SmtpClient())
            {
                await smtpClient.SendMailAsync(mail);
            }
        }

    }
}
