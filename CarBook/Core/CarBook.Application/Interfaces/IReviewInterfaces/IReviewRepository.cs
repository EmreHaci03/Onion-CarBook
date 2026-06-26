using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.IReviewInterfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewList();
        Task<List<Review>> GetReviewListByCarId(int carId);
        Task<Review> GetReviewWithCarById(int id);
    }
}
