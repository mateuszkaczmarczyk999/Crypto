using System;
using CryptoApp.Enums;

namespace CryptoApp.Models
{
    public class Market
    {
        private static readonly Lazy<Market> _instance =
            new Lazy<Market>(() => new Market());

        public decimal[][] Rates;

        public static Market GetInstance()
        {
            return _instance.Value;
        }


        public bool Exchange(CurrenciesSignatures toSell, CurrenciesSignatures toBuy, decimal quantity, IWallet wallet)
        {
            if (wallet.IsEnoughFunds(toSell, quantity))
            {
                wallet.SubstractFunds(toSell, quantity);
                wallet.AddFunds(toBuy, quantity * Rates[(int)toSell][(int)toBuy]);

                return true;
            }
            return false;
        }
    }
}