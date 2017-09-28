using CryptoApp.Models;
using Microsoft.AspNet.SignalR;

namespace CryptoApp.Hubs
{
    public class MarketHub : Hub
    {
        private readonly Market _market;

        public MarketHub() : this(Market.GetInstance()) { }

        public MarketHub(Market market)
        {
            _market = market;
        }

    }
}