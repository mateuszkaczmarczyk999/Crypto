using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Owin;

namespace CryptoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}