using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.ReservationResults
{
    public class GetReservationQueryResult
    {
        public int ReservationId { get; set; }
        public string ReservationName { get; set; }
        public string ReservationSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public int CarPricingId { get; set; }
        public string PricingType { get; set; }
        public int Amount { get; set; }
        public int? PickUpLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public string PickUpLocationName { get; set; }
        public string DropOffLocationName { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string? Description { get; set; }
        public DateTime? PickUpDate { get; set; }
        public DateTime? DropOffDate { get; set; }
        public string Status { get; set; }
    }
}
