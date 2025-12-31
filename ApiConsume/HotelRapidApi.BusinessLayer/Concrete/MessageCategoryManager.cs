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
    public class MessageCategoryManager(IMessageCategoryDal _messageCategoryDal) : IMessageCategoryService
    {
        public void TDelete(MessageCategory entity)
        {
            _messageCategoryDal.Delete(entity);
        }

        public MessageCategory TGetById(int id)
        {
           return _messageCategoryDal.GetById(id);
        }

        public List<MessageCategory> TGetList()
        {
           return _messageCategoryDal.GetList();
        }

        public void TInsert(MessageCategory entity)
        {
           _messageCategoryDal.Insert(entity);
        }

        public void TUpdate(MessageCategory entity)
        {
           _messageCategoryDal.Update(entity);
        }
    }
}
