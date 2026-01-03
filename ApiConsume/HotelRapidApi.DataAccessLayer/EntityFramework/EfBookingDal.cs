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

        public void BookingStatusChangeApproved(Booking booking)
        {

            var values = _appDbContext.Bookings.Where(x => x.Id == booking.Id).FirstOrDefault();
            values.Status = "Onaylandı";
            _appDbContext.SaveChanges();
        }

        public void BookingStatusChangeApproved2(int id)
        {

            var values = _appDbContext.Bookings.Find(id);
            values.Status = "Onaylandı";
            _appDbContext.SaveChanges();
        }

        public void BookingStatusChangeApproved3(int id)
        {

            var values = _appDbContext.Bookings.Find(id);
            values.Status = "Onaylandı";
            _appDbContext.SaveChanges();
        }

        public void BookingStatusChangeCancel(int id)
        {

            var values = _appDbContext.Bookings.Find(id);
            values.Status = "İptal Edildi";
            _appDbContext.SaveChanges();
        }

        public void BookingStatusChangeWait(int id)
        {
            var values = _appDbContext.Bookings.Find(id);
            values.Status = "Müşteri Aranacak";
            _appDbContext.SaveChanges();
        }

        public int GetBookingCount()
        {

            var value = _appDbContext.Bookings.Count();
            return value;
        }

        public List<Booking> Last6Bookings()
        {
            var values = _appDbContext.Bookings.OrderByDescending(x => x.Id).Take(6).ToList();
            return values;
        }

    }
}
