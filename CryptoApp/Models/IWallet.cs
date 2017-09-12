using System;

namespace CryptoApp.Models
{
    public interface IWallet
    {
        bool IsEnoughFunds(CurrencySignatures toSell, decimal quantity);

        bool SubstractFunds(CurrencySignatures toSell, decimal quantity);

        bool AddFunds(CurrencySignatures toBuy, decimal quantity);
    }
}
