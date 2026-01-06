using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.MessageCategoryDtos;
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
    public class MessageCategoryManager(IMessageCategoryDal _messageCategoryDal) : IMessageCategoryService
    {
        public async Task CreateAsync(CreateMessageCategoryDto create)
        {
            var messageCategory = create.Adapt<MessageCategory>();
            await _messageCategoryDal.CreateAsync(messageCategory);
        }

        public async Task DeleteAsync(int id)
        {
            var messageCategory = await _messageCategoryDal.GetByIdAsync(id);
            await _messageCategoryDal.DeleteAsync(messageCategory);
        }

        public async Task<ResultMessageCategoryDto> GetByIdAsync(int id)
        {
            var messageCategory=await _messageCategoryDal.GetByIdAsync(id);
            return messageCategory.Adapt<ResultMessageCategoryDto>();
        }

        public async Task<List<ResultMessageCategoryDto>> GetListAsync()
        {
           var messageCategory=await _messageCategoryDal.GetListAsync();
            return messageCategory.Adapt<List<ResultMessageCategoryDto>>();
        }

        public async Task UpdateAsync(UpdateMessageCategoryDto update)
        {
           var messageCategory=update.Adapt<MessageCategory>();
             await _messageCategoryDal.UpdateAsync(messageCategory);
        }
    }
}
