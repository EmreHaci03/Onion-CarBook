using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public List<RentACar> rentACars { get; set; }
        public List<RentACarProcess> DropOffProcesses { get; set; }

        public List<Reservation> PickUpReservation { get; set; }
        public List<Reservation> DropOffReservation { get; set; }

    }
}
