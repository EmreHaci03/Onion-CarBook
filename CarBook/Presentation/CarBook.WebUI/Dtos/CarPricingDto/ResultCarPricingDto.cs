namespace CarBook.WebUI.Dtos.CarPricingDto
{
    public class ResultCarPricingDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarWithModel { get; set; }

        public int PricingId { get; set; }
        public string PricingType { get; set; }
        public decimal Amount { get; set; }
    }
}
