using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cinema.Web.Startup))]
namespace Cinema.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
