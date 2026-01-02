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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly AppDbContext _appDbContext;

        public EfBookingDal(AppDbContext context, AppDbContext appDbContext) : base(context)
        {
            _appDbContext = appDbContext;
        }

        public int GetBookingCount()
        {
            var value=_appDbContext.Bookings.Count();
            return value;

        }

        public List<Booking> Last6Bookings()
        {
            var values = _appDbContext.Bookings.OrderByDescending(x => x.Id).Take(6).ToList();
            return values;
        }
    }
}
