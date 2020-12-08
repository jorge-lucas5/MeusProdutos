using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Estudos.AppMVC.Startup))]
namespace Estudos.AppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
