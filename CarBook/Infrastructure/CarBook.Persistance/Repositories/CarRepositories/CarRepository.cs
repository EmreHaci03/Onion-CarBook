using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

    
        public  List<Car> GetCarsListWithBrands()
        {
            var values = _carBookContext.Cars.Include(x => x.Brand).ToList();
            return values;
        }

        public List<Car> GetCarsWithPricings()
        {
            return _carBookContext.Cars
                .Include(x => x.Brand)
                .Include(x => x.CarPricing)
                .ThenInclude(x => x.Pricing)
                .ToList();
        }

        public Car GetCarWithBrandByIdAsync(int id)
        {
            return _carBookContext.Cars
                .Include(x => x.Brand)
                .Include(x=>x.CarPricing)
                .ThenInclude(x => x.Pricing)    
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _carBookContext.Cars.Include(x => x.Brand).Include(x=>x.CarPricing).ThenInclude(z=>z.Pricing).OrderByDescending(x=>x.Id).Take(5).ToList();
            return values;
        }

        public Car ResultCarWithPricingForAdmin(int id)
        {
            return _carBookContext.Cars
                .Include(c => c.CarPricing)
                .ThenInclude(cp => cp.Pricing)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
