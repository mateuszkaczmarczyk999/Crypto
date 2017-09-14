using System;
using CryptoApp.Enums;

namespace CryptoApp.Models
{
    public class RatesEventArgs : EventArgs
    {
        public PriceAction PriceAction { get; set; }
        public CurrencySignature ChangeFrom { get; set; }
        public CurrencySignature ChangeTo { get; set; }
        public decimal Value { get; set; }
    }
}