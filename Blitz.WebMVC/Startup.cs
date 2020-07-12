using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blitz.WebMVC.Startup))]
namespace Blitz.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
