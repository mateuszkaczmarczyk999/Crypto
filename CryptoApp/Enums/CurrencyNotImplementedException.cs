using System;

namespace CryptoApp.Enums
{
    public class CurrencyNotImplementedException: Exception
    {
        public CurrencyNotImplementedException()
        {
        }

        public CurrencyNotImplementedException(string message)
            : base(message)
        {
        }

        public CurrencyNotImplementedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}