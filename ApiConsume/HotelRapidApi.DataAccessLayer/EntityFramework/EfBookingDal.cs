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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly AppDbContext _appDbContext;

        public EfBookingDal(AppDbContext context, AppDbContext appDbContext) : base(context)
        {
            _appDbContext = appDbContext;
        }

        public async Task BookingStatusChangeApproved(Booking booking)
        {
            var values = await _appDbContext.Bookings.Where(x => x.Id == booking.Id).FirstOrDefaultAsync();
            values.Status = "Onaylandı";
            await _appDbContext.SaveChangesAsync();
        }

        public async Task BookingStatusChangeApproved2(int id)
        {

            var values =await _appDbContext.Bookings.FindAsync(id);
            values.Status = "Onaylandı";
           await _appDbContext.SaveChangesAsync();
        }

        public async Task BookingStatusChangeApproved3(int id)
        {

            var values =await _appDbContext.Bookings.FindAsync(id);
            values.Status = "Onaylandı";
            await _appDbContext.SaveChangesAsync();
        }

        public async Task BookingStatusChangeCancel(int id)
        {

            var values= await _appDbContext.Bookings.FindAsync(id);
            values.Status = "İptal Edildi";
            await _appDbContext.SaveChangesAsync();
        }

        public async Task BookingStatusChangeWait(int id)
        {
            var values =await _appDbContext.Bookings.FindAsync(id);
            values.Status = "Müşteri Aranacak";
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> GetBookingCount()
        {

            var value= await _appDbContext.Bookings.CountAsync();
            return value;
        }

        public async Task <List<Booking>> Last6Bookings()
        {
            var values =await _appDbContext.Bookings.OrderByDescending(x => x.Id).Take(6).ToListAsync();
            return values;
        }

      
    }
}
