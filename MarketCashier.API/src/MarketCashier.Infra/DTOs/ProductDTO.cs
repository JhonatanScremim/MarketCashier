using System.ComponentModel.DataAnnotations;

namespace MarketCashier.Infra.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public long BarCode { get; set; }
    }
}