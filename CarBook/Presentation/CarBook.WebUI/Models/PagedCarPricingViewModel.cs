using CarBook.WebUI.Dtos.CarDto;

namespace CarBook.WebUI.Models
{
    public class PagedCarPricingViewModel
    {
        public List<ResultCarWithPricingDto> Items { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}
