using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class BookingManager (IBookingDal _bookingDal): IBookingService
    {

        public void TDelete(Booking entity)
        {
           _bookingDal.Delete(entity);
        }

        public Booking TGetById(int id)
        {
           return _bookingDal.GetById(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TInsert(Booking entity)
        {
            _bookingDal.Insert(entity);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
