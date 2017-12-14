using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RocamERP.CrossCutting.Identity.Models;

namespace RocamERP.CrossCutting.Identity.Managers
{
    public class RocamAppSignInManager : SignInManager<RocamAppUser, string>
    {
        public RocamAppSignInManager(RocamAppUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }
    }
}
