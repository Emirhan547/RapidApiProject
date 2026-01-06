using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.ContactDtos;
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
    public class ContactManager(IContactDal _contactDal) : IContactService
    {
        public async Task CreateAsync(CreateContactDto create)
        {
            var contact=create.Adapt<Contact>();
            await _contactDal.CreateAsync(contact);
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _contactDal.GetByIdAsync(id);
            await _contactDal.DeleteAsync(contact);
        }

        public async Task<ResultContactDto> GetByIdAsync(int id)
        {
           var contact=await _contactDal.GetByIdAsync(id);
            return contact.Adapt<ResultContactDto>();
        }

        public async Task<List<ResultContactDto>> GetListAsync()
        {
           var contacts=await _contactDal.GetListAsync();
            return contacts.Adapt<List<ResultContactDto>>();
        }

        public async Task<int> TGetContactCount()
        {
           return await _contactDal.GetContactCount();
        }

        public async Task UpdateAsync(UpdateContactDto update)
        {
           var contacts=update.Adapt<Contact>();
           await _contactDal.UpdateAsync(contacts);
        }
    }
}
