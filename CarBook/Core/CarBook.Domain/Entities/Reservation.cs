using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ReservationName { get; set;}
        public string ReservationSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CarId { get; set; }
        public int CarPricingId { get; set; }
        public int Amount   { get; set; }
        public int? PickUpLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear {  get; set; }
        public string? Description { get; set; }

        public DateTime? PickUpDate { get; set; }
        public DateTime? DropOffDate { get; set; }

        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }
        public Car Car { get; set; }
        public string Status { get; set; }

    }
}
