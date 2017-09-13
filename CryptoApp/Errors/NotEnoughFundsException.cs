using System;

namespace CryptoApp.Errors

{
    public class NotEnoughFundsException: Exception
    {
        public NotEnoughFundsException()
        {
        }

        public NotEnoughFundsException(string message)
            : base(message)
        {
        }

        public NotEnoughFundsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
       
}