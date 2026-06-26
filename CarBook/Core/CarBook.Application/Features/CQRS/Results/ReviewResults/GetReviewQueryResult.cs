using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.ReviewResults
{
    public class GetReviewQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int CleanlinessRating { get; set; }
        public int ComfortRating { get; set; }
        public int PriceRating { get; set; }
        public int DeliveryRating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
