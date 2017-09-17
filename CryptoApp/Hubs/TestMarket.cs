using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CryptoApp.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using CryptoRatesProvider;
using CryptoRatesProvider.Enums;

namespace CryptoApp.Hubs
{
    public class TestMarket
    {
        private readonly static Lazy<TestMarket> _instance = new Lazy<TestMarket>(() =>
            new TestMarket(GlobalHost.ConnectionManager.GetHubContext<MarketHub>().Clients));

        private readonly IHubConnectionContext<dynamic> _clients;
        private Random _ranGen;

        public TestMarket(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;
            _ranGen = new Random();
        }

        public static TestMarket GetInstance()
        {
            return _instance.Value;
        }


        public RatesEventArgs TestApiValuesUpdate()
        {
            RatesEventArgs args = new RatesEventArgs();

            int fromInt = _ranGen.Next(0, 4);
            CurrencySignature From = (CurrencySignature) fromInt;
            int toInt = _ranGen.Next(0, 4);
            CurrencySignature To = (CurrencySignature) toInt;
            Debug.WriteLine(From);
            Debug.WriteLine(To);
            args.Value = _ranGen.Next(0, 1000);
            args.ChangeFrom = From;
            args.ChangeTo = To;

            return args;
        }

        public void OnRatesUpdated(object source, RatesEventArgs args)
        {
            _clients.All.updateRates(args);
        }
    }
}