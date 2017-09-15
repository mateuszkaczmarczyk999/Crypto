using System;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

namespace CryptoRatesProvider
{
    public class CryptoCompareRatesProvider: IRatesProvider
    {
        public event EventHandler<RatesEventArgs> RatesUpdated;
        private const string Host = "wss://streamer.cryptocompare.com";
        private readonly CryptoCompareDataParser _dataParser;
        private Socket _socket;
        private readonly string[] _subscriberStrings;


        public CryptoCompareRatesProvider(CryptoCompareDataParser parser, string[] subscriberStrings)
        {
            _dataParser = parser;
            _subscriberStrings = subscriberStrings;
        }

        public void StartService()
        {
            _socket = IO.Socket(Host);
            _socket.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("connected");
                var subObject = new { subs = _subscriberStrings};
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
            if (args != null)
            {
                RatesUpdated?.Invoke(this, args);
            }
        }

    }
}