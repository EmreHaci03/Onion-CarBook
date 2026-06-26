using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.IReservationInterfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> ReservationList();
        Task UpdateAsync(Reservation entity);
    }
}
