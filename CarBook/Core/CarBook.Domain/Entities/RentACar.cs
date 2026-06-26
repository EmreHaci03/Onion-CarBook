using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentACar
    {
        public int RentACarId { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int PickUpLocationID { get; set; }
        public Location PickUpLocation { get; set; }
    
        public bool IsAvaliable { get; set; }

        public List<RentACarProcess> RentACarProcesses { get; set; }


    }
}
