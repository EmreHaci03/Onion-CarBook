using CarBook.Application.Interfaces.IStatisticInterfaces;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _carBookContext;

        public StatisticRepository(CarBookContext carBookContext)
        {
            this._carBookContext = carBookContext;
        }

        public int GetAutomaticCarCount()
        {
            var values= _carBookContext.Cars.Count(x=>x.Transmission==TransmissionType.Automatic);
            return values;
        }

        public int GetCarCount()
        {
            return _carBookContext.Cars.Count();
        }
        public async Task<(string CarName, int CheapestCarPriceDay)> GetCheapestPriceCar()
        {
            var car = await _carBookContext.Cars
           .Include(x => x.Brand)
           .SelectMany(x => x.CarPricing
               .Where(cp => cp.Pricing.Name == "Günlük")
               .Select(cp => new
               {
                   CarName = x.Brand.BrandName + " " + x.Model,
                   Price = cp.Amount
               }))
           .OrderBy(x => x.Price)
           .FirstOrDefaultAsync();

            if (car == null)
                return ("Araç Bulunamadı", 0);

            return (car.CarName, (((int)car.Price)));
        }

        public Dictionary<string, int> GetFuelTypeStats()
        {
            return _carBookContext.Cars
                .GroupBy(x => x.FuelType)
                .ToDictionary(g => g.Key.ToString(),g=>g.Count());
        }

        public async Task<(string CarName, int Mileage)> GetHighestMileageCar()
        {
            var Car = await _carBookContext.Cars.Include(b => b.Brand).OrderByDescending(x => x.Mileage).Select(g => new
            {
                CarName = g.Brand.BrandName + " " + g.Model,
                MileAge = g.Mileage
            }).FirstOrDefaultAsync();

            return (Car.CarName, Car.MileAge);
        }

        public async Task<(string CarName, int HighestCarPriceDay)> GetHighestPriceCar()
        {
            var car = await _carBookContext.Cars
                 .Include(x => x.Brand)
                 .SelectMany(x => x.CarPricing
                 .Where(cp => cp.Pricing.Name == "Günlük")
                 .Select(cp => new
                 {
                     CarName = x.Brand.BrandName + " " + x.Model,
                     Price = cp.Amount
                 }))
                 .OrderByDescending(x => x.Price)
                 .FirstOrDefaultAsync();

            return (car.CarName, (((int)car.Price)));
        }

        public async Task<(string Title, string AuthorName)> GetLastAddedBlogName()
        {
            var blog = await _carBookContext.Blogs
                .Include(y => y.Author)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            return (blog.Title, blog.Author.AuthorName);
        }

        public int GetManualCarCount()
        {
            var values = _carBookContext.Cars.Count(x => x.Transmission == TransmissionType.Manual);
            return values;
        }

        public async Task<(string BrandName, int CarCount)> GetMostCarBrand()
        {
            var MostCar = await _carBookContext.Cars.Include(x => x.Brand).GroupBy(x => x.Brand.BrandName).Select(g => new
            {
                BrandName = g.Key,
                CarCount = g.Count()
            }).OrderByDescending(x => x.CarCount).FirstOrDefaultAsync();

            if (MostCar == null)
                return ("Marka Bulunamadı",0);

            return (MostCar.BrandName, MostCar.CarCount);
        }

        public async Task<(string FuelType, int FuelTypeCount)> GetMostUsedFuelType()
        {
            var fuelType = await _carBookContext.Cars
                .GroupBy(x => x.FuelType)
                .Select(g => new
                {
                    FuelType = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .FirstOrDefaultAsync();

            if (fuelType == null)
                return ("Yakıt Tipi Bulunamadı", 0);

            return (fuelType.FuelType.ToString(), fuelType.Count);
        }

        public async Task<(string BrandName, string CarModel)> GetNewestCarName()
        {
            var car = await _carBookContext.Cars.Include(x => x.Brand).OrderBy(x => x.Id).FirstOrDefaultAsync();
            return (car.Brand.BrandName, car.Model);
        }

        public async Task<(string BrandName, string CarModel)> GetOldestCarName()
        {
            var car = await _carBookContext.Cars.Include(x => x.Brand).OrderByDescending(z => z.Id).FirstOrDefaultAsync();
            return (car.Brand.BrandName,car.Model);
    }

        public int GetReservationCount()
        {
            return _carBookContext.Reservations.Count();
        }

        public async Task<(int CommentCount, string BlogName)> MostCommentedBlogTitle()
        {
            var comments = await _carBookContext.Comments.Include(x => x.Blog).GroupBy(x => x.Blog.Id).Select(g => new
            {
                BlogId = g.Key,
                CommentCount = g.Count(),
                BlogName=g.Select(x=>x.Blog.Title).FirstOrDefault()
            }).OrderByDescending(x => x.CommentCount).FirstOrDefaultAsync();

            if (comments == null)
                return (0, "Yorum Yok");

            return (comments.CommentCount, comments.BlogName);
        }

    }
}
