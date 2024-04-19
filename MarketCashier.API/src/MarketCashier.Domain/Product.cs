namespace MarketCashier.Domain
{
    public class Product
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public double Value { get; set; }
        public long BarCode { get; set; }
    }
}