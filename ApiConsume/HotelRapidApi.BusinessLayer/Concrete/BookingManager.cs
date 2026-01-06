using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.BookingDtos;
using HotelRapidApi.EntityLayer.Entities;
using Mapster;
using MapsterMapper;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class BookingManager(IBookingDal _bookingDal) : IBookingService
    {
        public async Task CreateAsync(CreateBookingDto create)
        {
            var booking = create.Adapt<Booking>();
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
            return booking.Adapt<ResultBookingDto>( );
        }

        public async Task<List<ResultBookingDto>> GetListAsync()
        {
            var bookings = await _bookingDal.GetListAsync();
            return bookings.Adapt<List<ResultBookingDto>>();
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
            return bookings.Adapt<List<ResultBookingDto>>();
        }

        // ✅ UPDATE

        public async Task UpdateAsync(UpdateBookingDto update)
        {
            var booking = update.Adapt<Booking>();
            await _bookingDal.UpdateAsync(booking);
        }
    }
}
