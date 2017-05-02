using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(McStanleyBar.Startup))]
namespace McStanleyBar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
