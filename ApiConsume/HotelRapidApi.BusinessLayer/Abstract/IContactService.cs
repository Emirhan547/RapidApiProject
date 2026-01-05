using HotelRapidApi.DtoLayer.DTOs.ContactDtos;
using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IContactService:IGenericService<ResultContactDto,CreateContactDto,UpdateContactDto>
    {
        Task <int> TGetContactCount();

    }
}
