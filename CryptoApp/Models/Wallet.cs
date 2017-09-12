using System;

namespace CryptoApp.Models
{

    public class Wallet : IWallet
    {
        public string Id { get; set; }
        public Dictionary<CurrencySignatures, decimal>  MyCurrencies { get; set; }

        public Wallet()
        {

        }

    }
}
