using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionRepository
    {
        List<CarDescription> GetCarDescription();
        Task<CarDescription> GetCarDescriptionByCarId(int carId);
        Task<CarDescription> GetByIdAsync(int id);
        Task CreateAsync(CarDescription carDescription);
        Task UpdateAsync(CarDescription carDescription);
        Task RemoveAsync(CarDescription carDescription);
    }
}
