using System.Text;
using System.Text.Json;
using MarketCashier.Application.Interfaces;
using MarketCashier.Application.Models;
using MarketCashier.Domain;
using MarketCashier.Repository;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MarketCashier.Application
{
    public class RabbitMQMessageConsumer : IRabbitMQMessageConsumer
    {
        private readonly OrderRepository _orderRepository;
        private readonly IConfiguration _configuration;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQMessageConsumer(OrderRepository orderRepository, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            _configuration = configuration;

            var factory = new ConnectionFactory()
            {
                HostName = _configuration.GetValue<string>("RabbitMQSettings:HostName"),
                UserName = _configuration.GetValue<string>("RabbitMQSettings:Username"),
                Password = _configuration.GetValue<string>("RabbitMQSettings:Password")
            };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "Market order queue", false, false, false, arguments: null);
        }

        public async Task ConsumerCheckout()
        {

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (channel, ev) =>
            {
                try
                {
                    //Obter conteudo em um array de bytes e converter para uma string
                    var content = Encoding.UTF8.GetString(ev.Body.ToArray());
                    var order = JsonSerializer.Deserialize<CheckoutItems>(content);

                    ProccessOrder(order).GetAwaiter().GetResult();

                    //Exclui pedido da fila
                    _channel.BasicAck(ev.DeliveryTag, false);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            };
            _channel.BasicConsume("Market order queue", false, consumer);
        }

        public async Task ProccessOrder(CheckoutItems checkout)
        {
            var order = new Order()
            {
                PaymentInfo = checkout.PaymentType,
                TotalPrice = checkout.TotalPrice,
                Products = JsonSerializer.Serialize(checkout.Products)
            };

            await _orderRepository.CreateAsync(order);
        }
    }
}