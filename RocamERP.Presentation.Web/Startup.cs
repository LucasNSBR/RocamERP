using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RocamERP.Presentation.Web.Startup))]

namespace RocamERP.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
