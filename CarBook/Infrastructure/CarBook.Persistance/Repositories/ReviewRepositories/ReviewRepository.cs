using CarBook.Application.Interfaces.IReviewInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext carBookContext;

        public ReviewRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }

        public async Task<List<Review>> GetReviewList()
        {
            var review = carBookContext.Reviews.Include(x => x.Car).ThenInclude(x => x.Brand).ToList();
            return review;
        }

        public async Task<List<Review>> GetReviewListByCarId(int carId)
        {
            var Review=carBookContext.Reviews.Include(x=>x.Car).ThenInclude(x=>x.Brand).Where(x=>x.CarId==carId).ToList();
            return Review;
        }

        public async Task<Review> GetReviewWithCarById(int id)
        {
            var Review = carBookContext.Reviews.Include(x => x.Car).ThenInclude(x => x.Brand).Where(x => x.Id == id).FirstOrDefault();
            return Review;
        }
    }
}
