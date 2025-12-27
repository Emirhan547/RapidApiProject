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
    public class ServiceManager : IServiceService
    {
        private readonly IServicesDal _servicesDal;

        public ServiceManager(IServicesDal servicesDal)
        {
            _servicesDal = servicesDal;
        }

        public void TDelete(Service entity)
        {
            _servicesDal.Delete(entity);
        }

        public Service TGetById(int id)
        {
            return _servicesDal.GetById(id);
        }

        public List<Service> TGetList()
        {
            return _servicesDal.GetList();
        }

        public void TInsert(Service entity)
        {
            _servicesDal.Insert(entity);
        }

        public void TUpdate(Service entity)
        {
            _servicesDal.Update(entity);
        }
    }
}
