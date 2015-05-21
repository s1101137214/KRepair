using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KuasRepair.Startup))]
namespace KuasRepair
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
