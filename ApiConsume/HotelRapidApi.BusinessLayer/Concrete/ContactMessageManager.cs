using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.ContactMessageDtos;
using HotelRapidApi.EntityLayer.Entities;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class ContactMessageManager(IContactMessageDal _contactMessageDal) : IContactMessageService
    {
        public async Task CreateAsync(CreateContactMessageDto create)
        {
            var contact = create.Adapt<ContactMessage>();
            await _contactMessageDal.CreateAsync(contact);
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _contactMessageDal.GetByIdAsync(id);
            await _contactMessageDal.DeleteAsync(contact);
        }

        public async Task<ResultContactMessageDto> GetByIdAsync(int id)
        {
            var contact = await _contactMessageDal.GetByIdAsync(id);
            return contact.Adapt<ResultContactMessageDto>();
        }

        public async Task<List<ResultContactMessageDto>> GetListAsync()
        {
            var contacts = await _contactMessageDal.GetListAsync();
            return contacts.Adapt<List<ResultContactMessageDto>>();
        }

        public async Task<int> TGetContactCount()
        {
            return await _contactMessageDal.GetContactCount();
        }

        public async Task UpdateAsync(UpdateContactMessageDto update)
        {
            var contacts = update.Adapt<ContactMessage>();
            await _contactMessageDal.UpdateAsync(contacts);
        }
    }
}