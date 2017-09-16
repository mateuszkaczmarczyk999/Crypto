using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CryptoApp.Enums;
using CryptoApp.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

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


        public CurrenciesRatesEvantArgs TestApiValuesUpdate()
        {
            CurrenciesRatesEvantArgs args = new CurrenciesRatesEvantArgs();

            int fromInt = _ranGen.Next(0, 4);
            CurrenciesSignatures From = (CurrenciesSignatures) fromInt;
            int toInt = _ranGen.Next(0, 4);
            CurrenciesSignatures To = (CurrenciesSignatures) toInt;
            Debug.WriteLine(From);
            Debug.WriteLine(To);
            args.Value = _ranGen.Next(0, 1000);
            args.ChangeFrom = From;
            args.ChangeTo = To;

            return args;
        }

        public void OnRatesUpdated(object source, CurrenciesRatesEvantArgs args)
        {
            while (true)
            {
                args = TestApiValuesUpdate();
                _clients.All.updateRates(args);
                Task.Delay(1000);
            }
        }
    }
}