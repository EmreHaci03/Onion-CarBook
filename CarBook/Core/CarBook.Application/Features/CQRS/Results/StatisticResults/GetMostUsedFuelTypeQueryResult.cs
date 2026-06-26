using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.StatisticResults
{
    public class GetMostUsedFuelTypeQueryResult
    {
        public string FuelType { get; set; }
        public int FuelTypeCount { get; set; }
    }
}
