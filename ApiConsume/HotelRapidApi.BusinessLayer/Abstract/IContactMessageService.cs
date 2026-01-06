using HotelRapidApi.DtoLayer.DTOs.ContactMessageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IContactMessageService : IGenericService<ResultContactMessageDto, CreateContactMessageDto, UpdateContactMessageDto>
    {
        Task<int> TGetContactCount();

    }
}
