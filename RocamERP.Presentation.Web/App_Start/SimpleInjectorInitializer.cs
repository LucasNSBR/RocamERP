using Microsoft.Owin;
using RocamERP.CrossCutting.IoC;
using RocamERP.Presentation.Web;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace RocamERP.Presentation.Web
{
    public class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register(() =>
            {
                if(HttpContext.Current.Items["owin.environment"] == null && container.IsVerifying)
                {
                    return new OwinContext().Authentication;
                }

                return HttpContext.Current.GetOwinContext().Authentication;
            }, Lifestyle.Scoped);

            InitializeIdentityContainer(container);
            InitializeStandardContainer(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        public static void InitializeIdentityContainer(Container container)
        {
            IdentityContainer.RegisterServices(container);
        }

        public static void InitializeStandardContainer(Container container)
        {
            StandardContainer.RegisterServices(container);
        }
    }
}