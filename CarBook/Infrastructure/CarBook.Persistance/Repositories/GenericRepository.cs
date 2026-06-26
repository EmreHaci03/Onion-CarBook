using CarBook.Application.Interfaces;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repository
{
    public class GenericRepository<T> : IRepository<T> where T :class
    {
        private readonly CarBookContext carBookContext;

        public GenericRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }

        public async Task CreateAsync(T entity)
        {
            await carBookContext.Set<T>().AddAsync(entity);
            await carBookContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await carBookContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await carBookContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            carBookContext.Set<T>().Remove(entity);
            await carBookContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            carBookContext.Set<T>().Update(entity);
            await carBookContext.SaveChangesAsync();
        }
    }
}
