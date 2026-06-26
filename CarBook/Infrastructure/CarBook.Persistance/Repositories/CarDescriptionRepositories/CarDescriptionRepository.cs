using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

public class CarDescriptionRepository : ICarDescriptionRepository
{
    private readonly CarBookContext carBookContext;
    public CarDescriptionRepository(CarBookContext carBookContext)
    {
        this.carBookContext = carBookContext;
    }

    public List<CarDescription> GetCarDescription()
    {
        return carBookContext.CarDescriptions.Include(x => x.Car).ToList();
    }

    public async Task<CarDescription> GetCarDescriptionByCarId(int carId)
    {
        return await carBookContext.CarDescriptions
            .Where(x => x.CarId == carId)
            .Include(x => x.Car)
            .FirstOrDefaultAsync();
    }

    public async Task<CarDescription> GetByIdAsync(int id)
    {
        return await carBookContext.CarDescriptions
            .Include(x => x.Car)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(CarDescription carDescription)
    {
        await carBookContext.CarDescriptions.AddAsync(carDescription);
        await carBookContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(CarDescription carDescription)
    {
        carBookContext.CarDescriptions.Update(carDescription);
        await carBookContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(CarDescription carDescription)
    {
        carBookContext.CarDescriptions.Remove(carDescription);
        await carBookContext.SaveChangesAsync();
    }
}