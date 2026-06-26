using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessId { get; set; }
        public int RentACarId { get; set; }
        public RentACar RentACar { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int DropOffLocationId { get; set; }
        public Location DropOffLocation { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string? PickUpDescription { get; set; }
        public string? DropOffDescription { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
