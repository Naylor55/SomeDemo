using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWebSite03.Startup))]
namespace MVCWebSite03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
