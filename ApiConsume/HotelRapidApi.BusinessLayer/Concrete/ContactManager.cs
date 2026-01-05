using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.ContactDtos;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class ContactManager(IContactDal _contactDal, IMapper _mapper) : IContactService
    {
        public async Task CreateAsync(CreateContactDto create)
        {
            var contact=_mapper.Map<Contact>(create);
            await _contactDal.CreateAsync(contact);
        }

        public async Task DeleteAsync(int id)
        {
            await _contactDal.DeleteAsync(id);
        }

        public async Task<ResultContactDto> GetByIdAsync(int id)
        {
           var contact=await _contactDal.GetByIdAsync(id);
            return _mapper.Map<ResultContactDto>(contact);
        }

        public async Task<List<ResultContactDto>> GetListAsync()
        {
           var contacts=await _contactDal.GetListAsync();
            return _mapper.Map<List<ResultContactDto>>(contacts);
        }

        public async Task<int> TGetContactCount()
        {
           return await _contactDal.GetContactCount();
        }

        public async Task UpdateAsync(UpdateContactDto update)
        {
           var contacts=_mapper.Map<Contact>(update);
           await _contactDal.UpdateAsync(contacts);
        }
    }
}
