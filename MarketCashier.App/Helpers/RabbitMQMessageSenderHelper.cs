using MarketCashier.App.Models;
using MarketCashier.App.Settings;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace MarketCashier.App.Helpers
{
    public class RabbitMQMessageSenderHelper
    {
        private readonly string _hostName;
        private readonly string _username;
        private readonly string _password;
        private readonly string _queueName;
        private IConnection? _connection;

        public RabbitMQMessageSenderHelper()
        {
            _hostName = RabbitMQSettings.HostName;
            _username = RabbitMQSettings.Username;
            _password = RabbitMQSettings.Password;
            _queueName = RabbitMQSettings.QueueName;
        }

        public bool SendMessage(CheckoutItems baseMessage)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                UserName = _username,
                Password = _password
            };
            _connection = factory.CreateConnection();

            using (var channel = _connection.CreateModel())
            {
                // Declara a fila se ela não existir
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Habilita confirmações do publicador
                channel.ConfirmSelect();

                byte[] body = GetMessageAsByteArray(baseMessage);

                // Publica a mensagem
                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: null,
                                     body: body);

                // Aguarda a confirmação
                if (channel.WaitForConfirms())
                    return true;
                else
                    return false;
            }
        }

        private byte[] GetMessageAsByteArray(CheckoutItems baseMessage)
        {
            var json = JsonConvert.SerializeObject(baseMessage);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
