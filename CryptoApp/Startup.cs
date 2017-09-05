using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CryptoApp.Startup))]
namespace CryptoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
