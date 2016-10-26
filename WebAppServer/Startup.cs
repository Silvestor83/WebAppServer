using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppServer.Startup))]
namespace WebAppServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
