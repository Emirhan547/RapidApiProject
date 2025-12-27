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
    public class GuestManager(IGuestDal _guestDal) : IGuestService
    {
        public void TDelete(Guest entity)
        {
           _guestDal.Delete(entity);    
        }

        public Guest TGetById(int id)
        {
           return _guestDal.GetById(id);
        }

        public List<Guest> TGetList()
        {
           return _guestDal.GetList();
        }

        public void TInsert(Guest entity)
        {
            _guestDal.Insert(entity);
        }

        public void TUpdate(Guest entity)
        {
            _guestDal.Update(entity);
        }
    }
}
