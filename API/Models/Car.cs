namespace API.Models
{
    public sealed class Car
    {
        public Guid Id { get; set; }
        public string? Maker { get; set; }

        public string? Model { get; set; }
        public int Mileage { get; set; }
    }
}
