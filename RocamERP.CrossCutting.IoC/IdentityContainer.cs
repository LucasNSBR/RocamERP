using Microsoft.AspNet.Identity;
using RocamERP.CrossCutting.Identity.Managers;
using RocamERP.CrossCutting.Identity.Models;
using SimpleInjector;
using RocamERP.CrossCutting.Identity.Context;

namespace RocamERP.CrossCutting.IoC
{
    public class IdentityContainer
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IUserStore<RocamAppUser>, RocamAppUserStore>(Lifestyle.Scoped);
            container.Register<RocamAppDbContext, RocamAppDbContext>(Lifestyle.Scoped);
            container.Register<RocamAppUserManager, RocamAppUserManager>(Lifestyle.Scoped);
            container.Register<RocamAppSignInManager, RocamAppSignInManager>(Lifestyle.Scoped);
        }
    }
}
