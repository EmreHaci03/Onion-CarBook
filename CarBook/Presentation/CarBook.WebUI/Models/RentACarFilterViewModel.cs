using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Models
{
    public class RentACarFilterViewModel
    {
        public int? PickUpLocationId { get; set; }

        public DateTime? PickUpDate { get; set; }
        public DateTime? DropOffDate { get; set; }

        public List<SelectListItem> Locations { get; set; }
    }
}
