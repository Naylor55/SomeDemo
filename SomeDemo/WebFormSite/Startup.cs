using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormSite.Startup))]
namespace WebFormSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
