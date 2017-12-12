using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace RocamERP.CrossCutting.Identity.Services
{
    public class IdentityEmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            throw new NotImplementedException();
        }

        private IdentityEmailService()
        {
        }

        public static IdentityEmailService Create()
        {
            return new IdentityEmailService();
        }
    }
}
