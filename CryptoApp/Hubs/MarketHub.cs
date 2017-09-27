using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using CryptoApp.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CryptoApp.Hubs
{
    public class MarketHub : Hub
    {
        private readonly TestMarket _market;

        public MarketHub() : this(TestMarket.GetInstance()) { }

        public MarketHub(TestMarket market)
        {
            _market = market;
        }
        
    }
}