using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCashier.App.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public double Price { get; set; }
        public long BarCode { get; set; }
    }
}

