using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.ICarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetByCarIdWithDetailsAsync(int carId);
        Task UpdateAsync(CarFeature entity);
        Task CreateAsync(CarFeature carFeature);
    }
}
