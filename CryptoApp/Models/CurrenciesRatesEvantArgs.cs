using System;
using CryptoApp.Enums;

namespace CryptoApp.Models
{
    public class CurrenciesRatesEvantArgs : EventArgs
    {
        public CurrenciesSignatures ChangeFrom { get; set; }
        public CurrenciesSignatures ChangeTo { get; set; }
        public decimal Value { get; set; }
    }
}