﻿using CryptoApp.Hubs;
using CryptoRatesProvider;
using CryptoRatesProvider.Enums;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Diagnostics;

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
            Rates = SetSelfRates(new decimal[numberOfCurrencies, numberOfCurrencies]);
        }

        private decimal[,] SetSelfRates(decimal[,] rates)
        {
            for (var i = 0; i < rates.GetLength(0); i++)
            {
                rates[i,i] = 1;
            }
            return rates;
        }

        public static Market GetInstance()
        {
            return _instance.Value;
        }

        public bool Exchange(CurrencySignature toSell, CurrencySignature toBuy, decimal quantity, IWallet wallet)
        {
            if (wallet.HasEnoughFunds(toSell, quantity * Rates[(int)toBuy, (int)toSell]))
            {
                wallet.SubstractFunds(toSell, quantity * Rates[(int)toBuy, (int)toSell]);
                wallet.AddFunds(toBuy, quantity);

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