using Microsoft.AspNet.Identity;
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
            await Task.FromResult(0);
        }
    }
}
