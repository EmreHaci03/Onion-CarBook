using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarResults
{
    public class GetLast5CarsWithBrandsQueryResult
    {
        public int Id { get; set; }
        public String BrandName { get; set; } // Navigation property (EF Core tarafından doldurulabilir, null olabilir)
        public string? Model { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public int Mileage { get; set; }
        public TransmissionType Transmission { get; set; }
        public byte Seats { get; set; }
        public byte LuggageCapacity { get; set; }
        public FuelType FuelType { get; set; }
        public string DetailImageUrl { get; set; } = string.Empty;
        public List<CarPricingDto> Pricings { get; set; }

    }
}
