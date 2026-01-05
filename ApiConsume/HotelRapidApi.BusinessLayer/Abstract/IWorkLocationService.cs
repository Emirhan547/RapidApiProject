using HotelRapidApi.DtoLayer.DTOs.WorkLocationDtos;
using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IWorkLocationService:IGenericService<ResultWorkLocationDto,CreateWorkLocationDto,UpdateWorkLocationDto>
    {
    }
}
