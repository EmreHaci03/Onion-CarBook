using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {

        Task<CarPricing> GetByIdAsync(int id);

        Task<List<CarPricing>> GetByCarIdAsync(int CarId);
        Task<List<CarPricing>> CarPricingWithBrand();
        Task<CarPricing> CreateCarPricingAsync(CarPricing carPricing);
        Task<CarPricing> UpdateCarPricing(CarPricing carPricing);
        Task RemoveAsync(CarPricing carPricing);
    }
}
