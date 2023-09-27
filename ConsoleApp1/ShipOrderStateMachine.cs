using Automatonymous;
using Messages;
using System;


namespace Shipping
{
    public class ShipOrderStateMachine : MassTransitStateMachine<OrderState>
    {
        public ShipOrderStateMachine()
        {
            Event(() => orderPlaced, x => x.CorrelateById(context => context.Message.Id));
            Event(() => orderBilled, x => x.CorrelateById(context => context.Message.Id));
            Initially(
                When(orderPlaced)
                    .Then(context => Console.WriteLine("OrderPlaced message received."))
                    .TransitionTo(OrderPlaced)
            );
            During(OrderPlaced,
                When(orderBilled)
                    .Then(context => Console.WriteLine("OrderBilled message received." +
                    "\n ---------------------------------------------------------"))

                    .TransitionTo(OrderBilled)
            );

            SetCompletedWhenFinalized();
        }


        public Event<OrderPlaced> orderPlaced { get; private set; }
        public Event<OrderBilled> orderBilled { get; private set; }

        public State OrderPlaced { get; private set; }
        public State OrderBilled { get; private set; }
    }

}
