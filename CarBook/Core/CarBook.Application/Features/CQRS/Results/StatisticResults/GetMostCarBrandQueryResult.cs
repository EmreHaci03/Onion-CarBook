using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.StatisticResults
{
    public class GetMostCarBrandQueryResult
    {
        public string BrandName { get; set; }
        public int CarCount { get; set; }
    }
}
