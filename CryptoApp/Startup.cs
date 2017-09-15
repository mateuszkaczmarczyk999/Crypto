using System.Threading.Tasks;
using CryptoApp.Hubs;
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
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();

            //var testTask = Task.Run(() => TestApi.GetInstance().TestMethod());
        }
    }
}
