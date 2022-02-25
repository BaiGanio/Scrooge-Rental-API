namespace API
{
    public sealed class Car
    {
        public Guid Id { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string ImageUrl { get; set; }
        public string FuelType { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();

    }

    public enum Maker
    {
        Audi, BMW, Mercedes, Porsche, Tesla
    }
    public enum FuelType
    {
        Petrol, Diesel, Gas, Hybrid, Electric
    }
}
