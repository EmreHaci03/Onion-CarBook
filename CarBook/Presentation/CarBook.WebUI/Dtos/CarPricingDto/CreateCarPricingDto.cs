using System.Runtime.ConstrainedExecution;

namespace CarBook.WebUI.Dtos.CarPricingDto
{
    public class CreateCarPricingDto
    {
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public string PricingType { get; set; }
        public decimal Amount { get; set; }
    }
}
