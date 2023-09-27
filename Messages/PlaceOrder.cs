using System;

namespace Messages
{
    public class PlaceOrder
    {
        public string OrderId { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);

        public string UserId { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);

    }
}