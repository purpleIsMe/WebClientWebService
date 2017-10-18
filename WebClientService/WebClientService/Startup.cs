using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebClientService.Startup))]
namespace WebClientService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
