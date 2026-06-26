using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext carBookContext;

        public CarPricingRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }

        public async Task<List<CarPricing>> CarPricingWithBrand()
        {
            return await carBookContext.CarPricings
                .Include(x => x.Car)
                    .ThenInclude(x => x.Brand)
                .Include(x => x.Pricing)
                .ToListAsync();
        }

        public async Task<CarPricing> CreateCarPricingAsync(CarPricing carPricing)
        {
            await carBookContext.CarPricings.AddAsync(carPricing);
            await carBookContext.SaveChangesAsync();

            return carPricing;
        }

        public async Task<List<CarPricing>> GetByCarIdAsync(int CarId)
        {
            var values = await carBookContext.CarPricings
            .Include(x => x.Car)
                .ThenInclude(x => x.Brand)
            .Include(x => x.Pricing)
            .Where(x => x.CarId == CarId)
            .ToListAsync();

            return values;
        }

        public async Task<CarPricing> GetByIdAsync(int id)
        {
            return await carBookContext.CarPricings
                .Include(x => x.Car)
                    .ThenInclude(x => x.Brand)
                .Include(x => x.Pricing)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<CarPricing> GetCarPricingWithId(int id)
        {
            return await carBookContext.CarPricings
                .Include(x => x.Car)
                    .ThenInclude(x => x.Brand)
                .Include(x => x.Pricing)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(CarPricing carPricing)
        {
            carBookContext.CarPricings.Remove(carPricing);
            await carBookContext.SaveChangesAsync();
        }

        public async Task<CarPricing> UpdateCarPricing(CarPricing carPricing)
        {
            carBookContext.CarPricings.Update(carPricing);
            await carBookContext.SaveChangesAsync();

            return carPricing;
        }
       
    }
}