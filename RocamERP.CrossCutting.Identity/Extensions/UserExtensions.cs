using RocamERP.CrossCutting.Identity.Managers;
using System.Text;
using System.Threading.Tasks;

namespace RocamERP.CrossCutting.Identity.Extensions
{
    public static class UserExtensions
    {
        public static async Task SendConfirmationEmailAsync(this RocamAppUserManager manager, string userEmail)
        {
            var user = await manager.FindByEmailAsync(userEmail);
            if (user == null)
                return;

            var token = await manager.GenerateEmailConfirmationTokenAsync(user.Id);
            var subject = "Confirmação de E-mail";
            var url = new StringBuilder();
            url.AppendLine($"Seu código de confirmação é: {token}");
            url.Append($"<a href={0}>");
            url.Append($"Clique no link para confirmar sua conta.");
            url.Append($"</a>");

            await manager.SendEmailAsync(user.Id, subject, url.ToString());
        }
    }
}
