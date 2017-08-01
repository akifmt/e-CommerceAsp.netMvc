using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eCommerce.MvcWebUI.Startup))]
namespace eCommerce.MvcWebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
