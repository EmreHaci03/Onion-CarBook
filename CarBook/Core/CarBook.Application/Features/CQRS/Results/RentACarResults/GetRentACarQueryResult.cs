using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.RentACarResults
{
    public class GetRentACarQueryResult
    {
        public int CarId { get; set; }
        public string CarName { get; set; }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string CarImageUrl { get; set; }
    }
}
