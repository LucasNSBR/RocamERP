using Microsoft.Owin.Security;
using Owin;
using RocamERP.CrossCutting.Identity.Managers;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web
{
	public partial class Startup
	{
		public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<RocamAppUserManager>());
        }
	}
}