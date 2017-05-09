using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWebSite02.Startup))]
namespace MVCWebSite02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
