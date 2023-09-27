using System;

namespace Messages
{
    public class OrderPlaced 
    {
        public Guid Id { get; set; }
        public string OrderId { get; set; }
        public string UserId { get; set; }
    }
}