using System.ComponentModel.DataAnnotations;

namespace MarketCashier.Infra.Models
{
    public class PageParams
    {
        [Range(1, 50)]
        public int PageNumber { get; set; }
        [Range(1, 50)]
        public int PageSize { get; set; }
    }
}