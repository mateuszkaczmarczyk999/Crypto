using System;
using CryptoApp.Models;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

namespace CryptoApp.Utils
{
    public class CryptoCompareRatesProvider: IRatesProvider
    {
        public event EventHandler<RatesEventArgs> RatesUpdated;
        private const string Host = "wss://streamer.cryptocompare.com";
        private readonly CryptoCompareDataParser _dataParser;
        private Socket _socket;


        public CryptoCompareRatesProvider()
        {
            _dataParser = new CryptoCompareDataParser();
        }

        public void StartService()
        {
            _socket = IO.Socket(Host);
            _socket.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("connected");
                var subObject = new { subs = new string[] { "5~CCCAGG~ETH~EUR", "5~CCCAGG~BTC~EUR", "5~CCCAGG~LTC~EUR", "5~CCCAGG~ETH~BTC", "5~CCCAGG~ETH~LTC", "5~CCCAGG~BTC~LTC" } };
                _socket.Emit("SubAdd", JObject.FromObject(subObject));

            });

            _socket.On("m", (data) =>
            {
                UpdateRates(data.ToString());
            });
        }

        private void UpdateRates(string data)
        {
            var args = _dataParser.ParseData(data);
            OnRatesUpdated(args);
        }

        protected virtual void OnRatesUpdated(RatesEventArgs args)
        {
            if (args != null && RatesUpdated != null)
            {
                RatesUpdated(this, args);
            }
        }

    }
}