using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ReviewCommands
{
    public class CreateReviewCommand:IRequest
    {
        public int CarId { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int CleanlinessRating { get; set; }   
        public int ComfortRating { get; set; }        
        public int PriceRating { get; set; }        
        public int DeliveryRating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
