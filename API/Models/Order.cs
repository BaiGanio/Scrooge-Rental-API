namespace API
{
    public sealed class Order
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
