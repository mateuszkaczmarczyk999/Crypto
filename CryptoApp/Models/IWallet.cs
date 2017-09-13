using CryptoApp.Enums;

namespace CryptoApp.Models
{
    public interface IWallet
    {
        bool HasEnoughFunds(CurrenciesSignatures toSell, decimal quantity);

        void SubstractFunds(CurrenciesSignatures toSell, decimal quantity);

        void AddFunds(CurrenciesSignatures toBuy, decimal quantity);
    }
}