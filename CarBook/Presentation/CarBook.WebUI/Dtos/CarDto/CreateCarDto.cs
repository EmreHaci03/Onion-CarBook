namespace CarBook.WebUI.Dtos.CarDto
{
    public class CreateCarDto
    {
        public int BrandId { get; set; }
        public string? Model { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public int Mileage { get; set; }
        public string Transmission { get; set; }
        public byte Seats { get; set; }
        public byte LuggageCapacity { get; set; }
        public string FuelType { get; set; }
        public string DetailImageUrl { get; set; } = string.Empty;
    }
}
