using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.DataAccessLayer.Repositories;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal :  IAppUserDal
    {
        private readonly AppDbContext _dbContext;

        public EfAppUserDal(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AppUserCount()
        {
            return await _dbContext.Users.CountAsync();
             
        }

        public async Task<List<AppUser>> GetListAsync()
        {
              return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<AppUser>> UserListWithLocation()
        {
            return await _dbContext.Users.Include(x => x.WorkLocation).ToListAsync();
        }

        public async Task <List<AppUser>> UserListWithWorkLocations()
        {
           return await _dbContext.Users.Include(x=>x.WorkLocation).ToListAsync();

        }

    }
}