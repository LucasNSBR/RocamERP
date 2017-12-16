using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using Microsoft.AspNet.Identity;

namespace RocamERP.Presentation.Web
{
    public partial class Startup
	{
		public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/Logout"),
                ExpireTimeSpan = TimeSpan.FromDays(7),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

        }
	}
}