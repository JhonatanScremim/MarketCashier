namespace MarketCashier.Infra.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public double Value { get; set; }
        public long BarCode { get; set; }
    }
}