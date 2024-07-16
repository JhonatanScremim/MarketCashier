using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketCashier.Domain;

namespace MarketCashier.Application.Models
{
    public class CheckoutItems
{
    public string PaymentType { get; set; }
    public List<Product> Products { get; set; }
    public double TotalPrice { get; set; }
}
}