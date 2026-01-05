using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.DataAccessLayer.Repositories;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

public class EfContactDal : GenericRepository<Contact>, IContactDal
{
    private readonly AppDbContext _context;

    public EfContactDal(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> GetContactCount()
    {
        return await _context.Contacts.CountAsync();
    }
}
