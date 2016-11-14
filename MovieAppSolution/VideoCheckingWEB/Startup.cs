using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoCheckingWEB.Startup))]
namespace VideoCheckingWEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
