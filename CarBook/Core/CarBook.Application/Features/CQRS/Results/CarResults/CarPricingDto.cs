using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarResults
{
    public class CarPricingDto
    {
        public string PricingName { get; set; }
        public decimal Amount { get; set; }
    }
}
