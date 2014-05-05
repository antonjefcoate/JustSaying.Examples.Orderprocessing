using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComsumerSite.Startup))]
namespace ComsumerSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
