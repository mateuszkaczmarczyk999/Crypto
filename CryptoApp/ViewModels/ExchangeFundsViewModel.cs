using CryptoRatesProvider.Enums;
using System.ComponentModel.DataAnnotations;

namespace CryptoApp.ViewModels
{
    public class ExchangeFundsViewModel
    {
        [Required]
        public CurrencySignature ToBuy { get; set; }

        [Required]
        public CurrencySignature ToSell { get; set; }

        [Required]
        public decimal Quantity { get; set; }
    }
}