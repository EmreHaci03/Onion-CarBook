using CarBook.Application.Interfaces.IAppUserInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.IAppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarBookContext carBookContext;

        public AppUserRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }

        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            return await carBookContext.AppUsers.Include(x=>x.AppRole).Where(filter).FirstOrDefaultAsync();
        }
    }
}
