using System;

namespace CryptoApp.Models
{
    public interface IWallet
    {
        bool HasEnoughFunds(CurrencySignatures toSell, decimal quantity);

        void SubstractFunds(CurrencySignatures toSell, decimal quantity);

        void AddFunds(CurrencySignatures toBuy, decimal quantity);
    }
}
