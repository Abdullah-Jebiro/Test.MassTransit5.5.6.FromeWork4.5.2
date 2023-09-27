using System;

namespace Messages
{
    public class OrderBilled 
    {

        public Guid Id { get; set; }
        public string OrderId { get; set; }
        public string UserId { get; set; } 
    }
}