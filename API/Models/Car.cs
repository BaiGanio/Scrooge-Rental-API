namespace API
{
    public sealed class Car
    {
        public Guid Id { get; set; }
        public Maker Maker { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string ImageUrl { get; set; }
        public FuelType FuelType { get; set; }

    }

    public enum Maker
    {
        Audi, BMW, Mercedes, Porche, Tesla
    }
    public enum FuelType
    {
        Petrol, Diesel, Gas, Hybrid, Electric
    }
}
