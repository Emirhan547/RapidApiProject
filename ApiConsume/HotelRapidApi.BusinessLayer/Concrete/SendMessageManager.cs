using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.SendMessageDtos;
using HotelRapidApi.EntityLayer.Entities;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class SendMessageManager(ISendMessageDal _sendMessageDal) : ISendMessageService
    {
        public async Task CreateAsync(CreateSendMessageDto create)
        {
            var sendMessage =create.Adapt<SendMessage>();
            await _sendMessageDal.CreateAsync(sendMessage);
        }

        public async Task DeleteAsync(int id)
        {
            var sendMessage=await _sendMessageDal.GetByIdAsync(id);
           await _sendMessageDal.DeleteAsync(sendMessage);
        }

        public async Task<ResultSendMessageDto> GetByIdAsync(int id)
        {
           var sendMessage=await _sendMessageDal.GetByIdAsync(id);
            return sendMessage.Adapt<ResultSendMessageDto>();
        }

        public async Task<List<ResultSendMessageDto>> GetListAsync()
        {
            var sendMessage=await _sendMessageDal.GetListAsync();
            return sendMessage.Adapt<List<ResultSendMessageDto>>();
        }

        public async Task<int> TGetSendMessageCount()
        {
            return await _sendMessageDal.GetSendMessageCount();
        }

        public async Task UpdateAsync(UpdateSendMessageDto update)
        {
           var sendMessage=update.Adapt<SendMessage>();
            await _sendMessageDal.UpdateAsync(sendMessage);
        }
    }
}
