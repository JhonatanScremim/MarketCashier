namespace MarketCashier.Domain
{
    public class Order
    {
        public long Id { get; set; }
        public string? Products { get; set; }
        public double TotalPrice { get; set; }
        public string? PaymentInfo { get; set; }
    }
}