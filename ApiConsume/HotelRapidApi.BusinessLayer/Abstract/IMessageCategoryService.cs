

using HotelRapidApi.DtoLayer.DTOs.MessageCategoryDtos;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IMessageCategoryService:IGenericService<ResultMessageCategoryDto,CreateMessageCategoryDto,UpdateMessageCategoryDto>
    {
    }
}
