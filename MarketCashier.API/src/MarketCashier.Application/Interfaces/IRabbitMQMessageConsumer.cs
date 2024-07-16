namespace MarketCashier.Application.Interfaces
{
    public interface IRabbitMQMessageConsumer
    {
        Task ConsumerCheckout();
    }
}