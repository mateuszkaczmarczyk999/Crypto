using System;

namespace CryptoApp.Models
{
    public class CurrenciesRatesEvantArgs : EventArgs
    {
        public decimal[][] Rates { get; set; }
    }
}