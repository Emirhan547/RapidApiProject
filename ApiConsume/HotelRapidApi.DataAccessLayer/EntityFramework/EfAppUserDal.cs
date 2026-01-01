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
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        private readonly AppDbContext _dbContext;
        public EfAppUserDal(AppDbContext context) : base(context)
        {
        }

        public List<AppUser> UserListWithLocation()
        {
            return _dbContext.Users.Include(x => x.WorkLocation).ToList();
        }
    }
}