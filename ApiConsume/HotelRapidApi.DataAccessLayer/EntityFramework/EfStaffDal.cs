using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.DataAccessLayer.Repositories;
using HotelRapidApi.EntityLayer.Entities;
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

        public int GetStaffCount()
        {
            var value=_appDbContext.Staffs.Count();
            return value;
        }

        public List<Staff> Last4Staff()
        {
            var value=_appDbContext.Staffs.OrderByDescending(x=> x.Id).Take(4).ToList();
            return value;
        }
    }
}
