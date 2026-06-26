using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarPricingResults
{
    public class GetCarPricingQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarWithModel { get; set; }

        public int PricingId { get; set; }
        public string PricingType { get; set; }
        public decimal Amount { get; set; }
    }
}
