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

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(
                new Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationOptions()
                {
                    SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
                    ClientId = "768968563849-tkre8ra6ea8stinqshsdmq7kl2gdqvao.apps.googleusercontent.com",
                    ClientSecret = "W__IHeaNCpjr6zFxwRGd5z52"
                }
            );
        }
	}
}