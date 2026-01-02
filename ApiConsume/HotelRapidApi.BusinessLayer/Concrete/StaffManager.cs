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
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public void TDelete(Staff entity)
        {
            _staffDal.Delete(entity);
        }

        public Staff TGetById(int id)
        {
            return _staffDal.GetById(id);
        }

        public List<Staff> TGetList()
        {
           return _staffDal.GetList();
        }

        public int TGetStaffCount()
        {
           return _staffDal.GetStaffCount();
        }

        public void TInsert(Staff entity)
        {
            _staffDal.Insert(entity);
        }

        public List<Staff> TLast4Staff()
        {
            return _staffDal.Last4Staff();
        }

        public void TUpdate(Staff entity)
        {
            _staffDal.Update(entity);
        }
    }
}
