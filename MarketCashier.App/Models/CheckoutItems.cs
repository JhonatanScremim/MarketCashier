﻿using MarketCashier.App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCashier.App.Models
{
    public class CheckoutItems
    {
        public string PaymentType { get; set; }
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
