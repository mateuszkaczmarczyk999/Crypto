using System.ComponentModel;
using CryptoRatesProvider.Enums;
using System.ComponentModel.DataAnnotations;

namespace CryptoApp.ViewModels
{
    public class ExchangeFundsViewModel
    {
        [Required]
        [DisplayName("To buy")]
        public CurrencySignature ToBuy { get; set; }

        [Required]
        [DisplayName("Buy with")]
        public CurrencySignature ToSell { get; set; }

        [Required]
        public decimal Quantity { get; set; }
    }
}