using Hangfire;
using MarketCashier.Application.Interfaces;

namespace MarketCashier.Application
{
    public class HangfireJobs
    {
        public static void Start()
        {
            RecurringJob.AddOrUpdate<IRabbitMQMessageConsumer>(x => x.ConsumerCheckout(), Cron.MinuteInterval(5));
        }
    }
}