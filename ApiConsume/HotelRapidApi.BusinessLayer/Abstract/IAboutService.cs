using HotelRapidApi.DtoLayer.DTOs.AboutDtos;
using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IAboutService:IGenericService<ResultAboutDto,CreateAboutDto,UpdateAboutDto>
    {
    }
}
