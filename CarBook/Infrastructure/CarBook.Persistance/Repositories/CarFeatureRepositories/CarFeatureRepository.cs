using CarBook.Application.Interfaces.ICarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

public class CarFeatureRepository : ICarFeatureRepository
{
    private readonly CarBookContext carBookContext;
    public CarFeatureRepository(CarBookContext carBookContext)
    {
        this.carBookContext = carBookContext;
    }

    public async Task CreateAsync(CarFeature carFeature)
    {
        carBookContext.CarFeatures.Add(carFeature);
        await carBookContext.SaveChangesAsync();
    }

    public async Task<List<CarFeature>> GetByCarIdWithDetailsAsync(int carId)
    {
        return await carBookContext.CarFeatures
            .Include(x => x.Car)
            .ThenInclude(c => c.Brand)
            .Include(x => x.Feature)
            .Where(x => x.CarId == carId)  
            .ToListAsync();
    }

    public async Task UpdateAsync(CarFeature entity)
    {
        carBookContext.CarFeatures.Update(entity);
        await carBookContext.SaveChangesAsync();
    }
}