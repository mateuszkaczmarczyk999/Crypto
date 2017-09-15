using System.ComponentModel.DataAnnotations;
using CryptoApp.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApp.Models
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public CurrenciesSignatures CurrencySignature { get; set; }
        
        [Required]
        public decimal Value { get; set; }
        
        
    }
}