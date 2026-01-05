using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.BookingDtos;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class BookingManager(IBookingDal _bookingDal, IMapper _mapper) : IBookingService
    {
        public async Task CreateAsync(CreateBookingDto create)
        {
            var booking = _mapper.Map<Booking>(create);
            await _bookingDal.CreateAsync(booking);
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await _bookingDal.GetByIdAsync(id);
            await _bookingDal.DeleteAsync(booking);
        }

        public async Task<ResultBookingDto> GetByIdAsync(int id)
        {
            var booking = await _bookingDal.GetByIdAsync(id);
            return _mapper.Map<ResultBookingDto>(booking);
        }

        public async Task<List<ResultBookingDto>> GetListAsync()
        {
            var bookings = await _bookingDal.GetListAsync();
            return _mapper.Map<List<ResultBookingDto>>(bookings);
        }


        public async Task TBookingStatusChangeApproved(int id)
        {
            await _bookingDal.BookingStatusChangeApproved2(id);
        }

        public async Task TBookingStatusChangeApproved2(int id)
        {
            await _bookingDal.BookingStatusChangeApproved2(id);
        }

        public async Task TBookingStatusChangeApproved3(int id)
        {
            await _bookingDal.BookingStatusChangeApproved3(id);
        }

        public async Task TBookingStatusChangeCancel(int id)
        {
            await _bookingDal.BookingStatusChangeCancel(id);
        }

        public async Task TBookingStatusChangeWait(int id)
        {
            await _bookingDal.BookingStatusChangeWait(id);
        }

        public async Task<int> TGetBookingCount()
        {
            return await _bookingDal.GetBookingCount();
        }

        // ✅ LAST 6 BOOKINGS

        public async Task<List<ResultBookingDto>> TLast6Bookings()
        {
            var bookings = await _bookingDal.Last6Bookings();
            return _mapper.Map<List<ResultBookingDto>>(bookings);
        }

        // ✅ UPDATE

        public async Task UpdateAsync(UpdateBookingDto update)
        {
            var booking = _mapper.Map<Booking>(update);
            await _bookingDal.UpdateAsync(booking);
        }
    }
}
