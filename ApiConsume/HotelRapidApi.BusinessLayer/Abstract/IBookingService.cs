using HotelRapidApi.DtoLayer.DTOs.BookingDtos;
using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<ResultBookingDto,CreateBookingDto,UpdateBookingDto>
    {
         Task TBookingStatusChangeApproved(int id);

        Task TBookingStatusChangeApproved2(int id);
        Task<int> TGetBookingCount();
        Task<List<ResultBookingDto>> TLast6Bookings();
        Task TBookingStatusChangeApproved3(int id);
        Task TBookingStatusChangeCancel(int id);
        Task TBookingStatusChangeWait(int id);
    }
}
