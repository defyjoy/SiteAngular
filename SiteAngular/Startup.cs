using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteAngular.Startup))]
namespace SiteAngular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
