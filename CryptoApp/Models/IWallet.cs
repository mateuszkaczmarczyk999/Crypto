using CryptoRatesProvider.Enums;

namespace CryptoApp.Models
{
    public interface IWallet
    {
        bool HasEnoughFunds(CurrencySignature toSell, decimal quantity);

        void SubstractFunds(CurrencySignature toSell, decimal quantity);

        void AddFunds(CurrencySignature toBuy, decimal quantity);
    }
}