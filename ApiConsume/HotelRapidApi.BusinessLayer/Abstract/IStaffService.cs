using HotelRapidApi.DtoLayer.DTOs.StaffDtos;
using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IStaffService:IGenericService<ResultStaffDto,CreateStaffDto,UpdateStaffDto>
    {
        Task<int> TGetStaffCount();
        Task<List<ResultStaffDto>> TLast4Staff();  
    }
}
