namespace MarketCashier.Infra.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public double Price { get; set; }
        public long BarCode { get; set; }
    }
}