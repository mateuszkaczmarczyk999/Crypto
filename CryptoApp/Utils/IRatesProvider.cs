using System;
using System.Configuration;
using CryptoApp.Models;

namespace CryptoApp.Utils
{
    public interface IRatesProvider
    {
        event EventHandler<RatesEventArgs> RatesUpdated;

    }
}