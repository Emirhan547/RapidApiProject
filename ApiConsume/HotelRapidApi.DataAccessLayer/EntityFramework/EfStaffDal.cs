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
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        private readonly AppDbContext _appDbContext;
        public EfStaffDal(AppDbContext context, AppDbContext appDbContext) : base(context)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> GetStaffCount()
        {
            var value=await _appDbContext.Staffs.CountAsync();
            return value;
        }

        public async Task <List<Staff>> Last4Staff()
        {
            var value=await _appDbContext.Staffs.OrderByDescending(x=> x.Id).Take(4).ToListAsync();
            return value;
        }
    }
}
