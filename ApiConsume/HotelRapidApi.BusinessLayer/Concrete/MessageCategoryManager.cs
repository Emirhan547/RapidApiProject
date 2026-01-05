using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.MessageCategoryDtos;
using HotelRapidApi.DtoLayer.DTOs.SendMessageDtos;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class MessageCategoryManager(IMessageCategoryDal _messageCategoryDal, IMapper _mapper) : IMessageCategoryService
    {
        public async Task CreateAsync(CreateMessageCategoryDto create)
        {
            var messageCategory = _mapper.Map<MessageCategory>(create);
            await _messageCategoryDal.CreateAsync(messageCategory);
        }

        public async Task DeleteAsync(int id)
        {
            await _messageCategoryDal.DeleteAsync(id);
        }

        public async Task<ResultMessageCategoryDto> GetByIdAsync(int id)
        {
            var messageCategory=await _messageCategoryDal.GetByIdAsync(id);
            return _mapper.Map<ResultMessageCategoryDto>(messageCategory);
        }

        public async Task<List<ResultMessageCategoryDto>> GetListAsync()
        {
           var messageCategory=await _messageCategoryDal.GetListAsync();
            return _mapper.Map<List<ResultMessageCategoryDto>>(messageCategory);
        }

        public async Task UpdateAsync(UpdateMessageCategoryDto update)
        {
           var messageCategory=_mapper.Map<MessageCategory>(update);
             await _messageCategoryDal.UpdateAsync(messageCategory);
        }
    }
}
