using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RocamERP.CrossCutting.Identity.Services
{
    public class IdentitySmsService : IIdentityMessageService
    {
        private IdentitySmsService()
        {
        }

        public static IdentitySmsService Create()
        {
            return new IdentitySmsService();
        }

        public async Task SendAsync(IdentityMessage message)
        {
            string messageDestination = message.Destination;
            string messageBody = message.Body;
            string messageSubject = message.Subject;

            MailMessage mail = new MailMessage();

            using (SmtpClient smtpClient = new SmtpClient())
            {
                await Task.Run(() => smtpClient.SendAsync(mail, null));
            }
        }
    }
}
