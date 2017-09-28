using CryptoApp.Hubs;
using CryptoRatesProvider;
using CryptoRatesProvider.Enums;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace CryptoApp.Models
{
    public class Market
    {
        private static readonly Lazy<Market> _instance = new Lazy<Market>(() =>
            new Market(GlobalHost.ConnectionManager.GetHubContext<MarketHub>().Clients));

        private readonly IHubConnectionContext<dynamic> _clients;

        public decimal[,] Rates;

        public Market(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;
            var numberOfCurrencies = Enum.GetNames(typeof(CurrencySignature)).Length;
            Rates = new decimal[numberOfCurrencies, numberOfCurrencies];
        }

        public static Market GetInstance()
        {
            return _instance.Value;
        }

        public bool Exchange(CurrencySignature toSell, CurrencySignature toBuy, decimal quantity, IWallet wallet)
        {
            if (wallet.HasEnoughFunds(toSell, quantity))
            {
                wallet.SubstractFunds(toSell, quantity);
                wallet.AddFunds(toBuy, quantity * Rates[(int)toSell, (int)toBuy]);

                return true;
            }
            return false;
        }

        public void OnRatesUpdated(object source, RatesEventArgs args)
        {
            Rates[(int)args.ChangeFrom, (int)args.ChangeTo] = args.Value;
            Rates[(int)args.ChangeTo, (int)args.ChangeFrom] = 1 / args.Value;

            _clients.All.updateRates(args);
        }
    }
}