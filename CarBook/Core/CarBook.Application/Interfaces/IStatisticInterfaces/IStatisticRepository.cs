using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.IStatisticInterfaces
{
    public interface IStatisticRepository
    {
        int GetCarCount();
        Task<(string CarName, int CheapestCarPriceDay)> GetCheapestPriceCar();
        Task<(string CarName, int Mileage)> GetHighestMileageCar();
        Task<(string CarName, int HighestCarPriceDay)> GetHighestPriceCar();
        Task<(string Title, string AuthorName)> GetLastAddedBlogName();
        Task<(string BrandName, int CarCount)> GetMostCarBrand();
        Task<(string FuelType, int FuelTypeCount)> GetMostUsedFuelType();
        Task<(string BrandName, string CarModel)> GetNewestCarName();
        Task<(string BrandName, string CarModel)> GetOldestCarName();
        Task<(int CommentCount, string BlogName)> MostCommentedBlogTitle();

        Dictionary<string, int> GetFuelTypeStats();
        int GetReservationCount();
        int GetAutomaticCarCount();
        int GetManualCarCount();
    }
}
