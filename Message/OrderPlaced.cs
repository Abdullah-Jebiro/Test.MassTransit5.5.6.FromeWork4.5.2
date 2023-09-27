namespace Message
{
    public class OrderPlaced 
    {
        public Guid Id { get; set; }
        public string OrderId { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}