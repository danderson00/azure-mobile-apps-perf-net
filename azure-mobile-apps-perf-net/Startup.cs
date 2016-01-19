using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(net_perfService.Startup))]

namespace net_perfService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}