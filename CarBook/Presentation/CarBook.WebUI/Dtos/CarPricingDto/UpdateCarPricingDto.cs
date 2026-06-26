namespace CarBook.WebUI.Dtos.CarPricingDto
{
    public class UpdateCarPricingDto
    {
        public int Id { get; set; }
        public string PricingType { get; set; }
        public decimal Amount { get; set; }
    }
}
