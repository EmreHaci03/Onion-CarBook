using CarBook.Application.Interfaces.IReservationInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarBookContext carBookContext;

        public ReservationRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }

        public async Task<List<Reservation>> ReservationList()
        {
            var values = await carBookContext.Reservations
                .Include(x => x.Car)
                .ThenInclude(x => x.Brand)

                .Include(x => x.Car)
                .ThenInclude(x => x.CarPricing)
                .ThenInclude(x => x.Pricing)

                .Include(x => x.PickUpLocation)
                .Include(x => x.DropOffLocation)
                .ToListAsync();

            return values;
        }

        public async Task UpdateAsync(Reservation entity)
        {
            carBookContext.Reservations.Update(entity);
            await carBookContext.SaveChangesAsync();
        }
    }
}