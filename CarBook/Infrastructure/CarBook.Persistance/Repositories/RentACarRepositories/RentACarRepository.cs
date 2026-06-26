using CarBook.Application.Interfaces.IRentACarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext carBookContext;

        public RentACarRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            return await carBookContext.RentACars.Include(x=>x.Car).ThenInclude(x=>x.Brand).Include(x=>x.PickUpLocation).Where(filter).ToListAsync();

            //Async kullanılıyorsa Task Dönüş Tiplerinden biri olmak zorundadır.
        }

        public async Task<List<RentACar>> GetUnavailableCarsAsync(Expression<Func<RentACar, bool>> filter)
        {
            return await carBookContext.RentACars.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.PickUpLocation).Where(filter).ToListAsync();
        }
    }
}
