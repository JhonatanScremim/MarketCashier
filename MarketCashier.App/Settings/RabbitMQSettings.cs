namespace MarketCashier.App.Settings
{
    public static class RabbitMQSettings
    {
        public static string HostName { get; set; } = "localhost";
        public static string Username { get; set; } = "guest";
        public static string Password { get; set; } = "guest";
        public static string QueueName { get; set; } = "Market order queue";
    }
}
