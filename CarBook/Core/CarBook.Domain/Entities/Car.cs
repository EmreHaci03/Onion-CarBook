
using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; } // Navigation property (EF Core tarafından doldurulabilir, null olabilir)
        public string? Model { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public int Mileage { get; set; } 
        public TransmissionType Transmission { get; set; }
        public byte Seats { get; set; }
        public byte LuggageCapacity { get; set; }
        public FuelType FuelType { get; set; }
        public string DetailImageUrl { get; set; } = string.Empty;
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricing { get; set; }
        public List<RentACar> rentACars { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
