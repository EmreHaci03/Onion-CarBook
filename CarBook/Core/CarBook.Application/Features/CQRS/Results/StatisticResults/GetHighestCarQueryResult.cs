using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.StatisticResults
{
    public class GetHighestCarQueryResult
    {
        public string HighestPriceCarName { get; set; }
        public int HighestCarPriceDay { get; set; }
    }
}
