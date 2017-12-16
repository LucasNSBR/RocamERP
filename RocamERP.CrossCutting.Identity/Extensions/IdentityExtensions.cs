using RocamERP.CrossCutting.Identity.Managers;
using System.Text;
using System.Threading.Tasks;

namespace RocamERP.CrossCutting.Identity.Extensions
{
    public static class IdentityExtensions
    {
        public static async Task SendConfirmationEmailAsync(this RocamAppUserManager manager, string userEmail)
        {
            var user = await manager.FindByEmailAsync(userEmail);
            var token = await manager.GenerateEmailConfirmationTokenAsync(user.Id);

            var subject = "Confirmação de E-mail";
            var url = "http://localhost:57756/Manage/ConfirmEmail";

            var body = new StringBuilder();
            body.AppendLine($"Seu código de confirmação é: {token}");
            body.Append($"<a href=\"{url}?token={token}\">");
            body.Append($"Clique neste link para confirmar sua conta.");
            body.Append($"</a>");
            body.AppendLine().AppendLine().AppendLine().AppendLine().AppendLine();
            body.AppendLine("Caso o link acima não funcione, cole o link abaixo na barra de endereços do seu navegador.");
            body.AppendLine($"{url}?token={token}");

            await manager.SendEmailAsync(user.Id, subject, body.ToString());
        }

        public static async Task SendTwoFactorAuthenticationTokenEmailAsync(this RocamAppSignInManager manager, string userEmail)
        {

        }
    }
}
