using System;
using CryptoRatesProvider.Enums;

namespace CryptoRatesProvider
{
    public class RatesEventArgs : EventArgs
    {
        public PriceAction PriceAction { get; set; }
        public CurrencySignature ChangeFrom { get; set; }
        public CurrencySignature ChangeTo { get; set; }
        public decimal Value { get; set; }
    }
}