using Microsoft.AspNet.Identity;
using Ninject.Modules;
using RocamERP.CrossCutting.Identity.Context;
using RocamERP.CrossCutting.Identity.Managers;
using RocamERP.CrossCutting.Identity.Models;

namespace RocamERP.CrossCutting.IoC
{
    class NinjectIdentityModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IUserStore<RocamAppUser, string>>().To<RocamAppUserStore>().InSingletonScope().WithConstructorArgument("context", new RocamAppDbContext());
            Kernel.Bind<RocamAppUserManager>().ToSelf().InSingletonScope();
           
        }
    }
}
