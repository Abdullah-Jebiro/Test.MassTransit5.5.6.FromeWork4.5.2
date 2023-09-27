using MassTransit;
using Messages;
using System;
using System.Threading;

namespace Test.MassTransit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Test";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), h =>
                {
                    h.Username(RabbitMqConsts.UserName);
                    h.Password(RabbitMqConsts.Password);
                });
            });

            bus.StartAsync();
           
            
 
            while (true)
            {
                Console.WriteLine("Enter key");
                Console.ReadLine();
                Guid Id = Guid.NewGuid();
                string OrderId = Guid.NewGuid().ToString().Substring(0, 8);
                string UserId = Guid.NewGuid().ToString().Substring(0, 8);
                bus.Publish(new OrderPlaced() { Id = Id, OrderId = OrderId, UserId = UserId });
                bus.Publish(new OrderBilled() { Id = Id, OrderId = OrderId, UserId = UserId });

            }


            Console.WriteLine("Listening for Register Demand commands.. \n" +
                "Press enter to exit");
            Console.ReadLine();

            bus.StopAsync();
        }
    }
}
