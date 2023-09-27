using MassTransit.Saga;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;

namespace Shipping
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Console.Title = "Shipping";

            var sagaStateMachine = new ShipOrderStateMachine();
            var repository = new InMemorySagaRepository<OrderState>();

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), h =>
                {
                    h.Username(RabbitMqConsts.UserName);
                    h.Password(RabbitMqConsts.Password);
                });
                cfg.ReceiveEndpoint(RabbitMqConsts.TestServiceQueue, ep =>
                {


                    ep.StateMachineSaga(sagaStateMachine, repository);

                });

            });

            await bus.StartAsync();

            Console.WriteLine("Listening for Register Demand commands.. \n" + "Press enter to exit");
            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
