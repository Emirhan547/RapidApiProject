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
    public class WorkLocationManager(IWorkLocationDal _workLocation) : IWorkLocationService
    {
        public void TDelete(WorkLocation entity)
        {
            _workLocation.Delete(entity);
        }

        public WorkLocation TGetById(int id)
        {
           return _workLocation.GetById(id);
        }

        public List<WorkLocation> TGetList()
        {
            return _workLocation.GetList();
        }

        public void TInsert(WorkLocation entity)
        {
           _workLocation.Insert(entity);
        }

        public void TUpdate(WorkLocation entity)
        {
            _workLocation.Update(entity);
        }
    }
}
