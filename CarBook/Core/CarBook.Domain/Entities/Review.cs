using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int CleanlinessRating { get; set; }   
        public int ComfortRating { get; set; }        
        public int PriceRating { get; set; }     
        public int DeliveryRating { get; set; }     
        public DateTime CreatedDate { get; set; }
    }
}
