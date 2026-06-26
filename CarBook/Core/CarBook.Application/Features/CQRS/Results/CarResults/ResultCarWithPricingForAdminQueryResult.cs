using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarResults
{
    public class ResultCarWithPricingForAdminQueryResult
    {
        public int Id { get; set; }
        public List<CarPricingDto> Pricings { get; set; }
    }
}
