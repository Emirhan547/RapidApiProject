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
    public class SendMessageManager(ISendMessageDal _sendMessageDal) : ISendMessageService
    {
        public void TDelete(SendMessage entity)
        {
            _sendMessageDal.Delete(entity);
        }

        public SendMessage TGetById(int id)
        {
            return _sendMessageDal.GetById(id);
        }

        public List<SendMessage> TGetList()
        {
            return _sendMessageDal.GetList();
        }

        public int TGetSendMessageCount()
        {
            return _sendMessageDal.GetSendMessageCount();
        }

        public void TInsert(SendMessage entity)
        {
            _sendMessageDal.Insert(entity);
        }

        public void TUpdate(SendMessage entity)
        {
           _sendMessageDal.Update(entity);
        }
    }
}
