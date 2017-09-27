using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CryptoRatesProvider.Enums;

namespace CryptoApp.Models
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public CurrencySignature CurrencySignature { get; set; }
        
        [Required]
        public decimal Value { get; set; }
        
        
    }
}