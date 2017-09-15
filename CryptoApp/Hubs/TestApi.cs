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
    public class TestApi
    {
        private readonly static Lazy<TestApi> _instance = new Lazy<TestApi>(() =>
            new TestApi(GlobalHost.ConnectionManager.GetHubContext<MarketHub>().Clients));

        private readonly IHubConnectionContext<dynamic> _clients;

        public TestApi(IHubConnectionContext<dynamic> clients)
        {
            _clients = clients;
        }

        public static TestApi GetInstance()
        {
            return _instance.Value;
        }


        public CurrenciesRatesEvantArgs TestApiValuesUpdate()
        {
            var ranGen = new Random();
            CurrenciesRatesEvantArgs args = new CurrenciesRatesEvantArgs();
            CurrenciesSignatures From = CurrenciesSignatures.Btc;
            CurrenciesSignatures To = CurrenciesSignatures.Eur;
            args.Value = ranGen.Next();
            args.ChangeFrom = From;
            args.ChangeTo = To;

            return args;
        }

        public void OnRatesUpdated(object source, CurrenciesRatesEvantArgs args)
        {
            args = TestApiValuesUpdate();
            
        }

        public void TestMethod()
        {
            while (true)
            {
                Debug.WriteLine("DUPA");
                _clients.All.updateRates();
                Task.Delay(1000);
            }
        }

       
    }
}