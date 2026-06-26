using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.StatisticResults
{
    public class GetCheapestCarQueryResult
    {
        public string CarName { get; set; }
        public int CheapestCarPriceDay { get; set; }

    }
}
