using Automatonymous;
using System;
using MassTransit;

namespace Shipping
{
    public class OrderState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }


    }
}
