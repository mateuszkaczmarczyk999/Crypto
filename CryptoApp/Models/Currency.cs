using System.ComponentModel.DataAnnotations;
using CryptoApp.Enums;

namespace CryptoApp.Models
{
    public class Currency
    {
        public string Id { get; set; }
        
        [Required]
        public CurrenciesSignatures CurrencySignature { get; set; }
        
        [Required]
        public decimal Value { get; set; }
        
        
    }
}