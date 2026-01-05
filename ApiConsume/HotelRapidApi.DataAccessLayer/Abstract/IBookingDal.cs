using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        Task BookingStatusChangeApproved(Booking booking);
        Task BookingStatusChangeApproved2(int id);
        Task<int> GetBookingCount();
        Task<List<Booking>> Last6Bookings();
        Task BookingStatusChangeApproved3(int id);
        Task BookingStatusChangeCancel(int id);
        Task BookingStatusChangeWait(int id);

    }
}
