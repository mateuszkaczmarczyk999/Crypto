using System;

namespace CryptoRatesProvider
{
    public interface IRatesProvider
    {
        event EventHandler<RatesEventArgs> RatesUpdated;
        void StartService();

    }
}