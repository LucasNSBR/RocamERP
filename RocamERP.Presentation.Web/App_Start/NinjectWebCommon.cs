[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RocamERP.Presentation.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RocamERP.Presentation.Web.App_Start.NinjectWebCommon), "Stop")]

namespace RocamERP.Presentation.Web.App_Start
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using RocamERP.Application;
    using RocamERP.Application.Interfaces;
    using RocamERP.CrossCutting.Identity.Context;
    using RocamERP.CrossCutting.Identity.Managers;
    using RocamERP.CrossCutting.Identity.Models;
    using RocamERP.Domain.RepositoryInterfaces;
    using RocamERP.Domain.ServiceInterfaces;
    using RocamERP.Infra.Data.Repositories;
    using RocamERP.Services.Services;
    using System;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //APPLICATION SERVICES
            kernel.Bind(typeof(IBaseApplicationService<>)).To(typeof(BaseApplicationService<>));
            kernel.Bind<IEstadoApplicationService>().To(typeof(EstadoApplicationService));
            kernel.Bind<ICidadeApplicationService>().To(typeof(CidadeApplicationService));
            kernel.Bind<IBancoApplicationService>().To(typeof(BancoApplicationService));
            kernel.Bind<IContatoApplicationService>().To(typeof(ContatoApplicationService));
            kernel.Bind<IEnderecoApplicationService>().To(typeof(EnderecoApplicationService));
            kernel.Bind<IChequeApplicationService>().To(typeof(ChequeApplicationService));
            kernel.Bind<IPessoaApplicationService>().To(typeof(PessoaApplicationService));


            //SERVICES
            kernel.Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            kernel.Bind<IEstadoService>().To(typeof(EstadoService));
            kernel.Bind<ICidadeService>().To(typeof(CidadeService));
            kernel.Bind<IBancoService>().To(typeof(BancoService));
            kernel.Bind<IContatoService>().To(typeof(ContatoService));
            kernel.Bind<IEnderecoService>().To(typeof(EnderecoService));
            kernel.Bind<IChequeService>().To(typeof(ChequeService));
            kernel.Bind<IPessoaService>().To(typeof(PessoaService));


            //REPOSITORIES
            kernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            kernel.Bind<IEstadoRepository>().To(typeof(EstadoRepository));
            kernel.Bind<ICidadeRepository>().To(typeof(CidadeRepository));
            kernel.Bind<IBancoRepository>().To(typeof(BancoRepository));
            kernel.Bind<IContatoRepository>().To(typeof(ContatoRepository));
            kernel.Bind<IEnderecoRepository>().To(typeof(EnderecoRepository));
            kernel.Bind<IChequeRepository>().To(typeof(ChequeRepository));
            kernel.Bind<IPessoaRepository>().To(typeof(PessoaRepository));

            
            ////TODO: FIX THESE INJECTIONS
            //kernel.Bind<RocamAppDbContext>().ToSelf().InRequestScope();
            //kernel.Bind<IUserStore<RocamAppUser>>().To<RocamAppUserStore>();
            //kernel.Bind<RocamAppUserStore>().ToSelf().InRequestScope();
            //kernel.Bind<IAuthenticationManager>().ToMethod(m => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            //kernel.Bind<RocamAppSignInManager>().ToSelf().InRequestScope();

        }
    }
}
