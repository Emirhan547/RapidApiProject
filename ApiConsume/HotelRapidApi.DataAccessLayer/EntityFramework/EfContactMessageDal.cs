using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.DataAccessLayer.Repositories;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

public class EfContactMessageDal : GenericRepository<ContactMessage>, IContactMessageDal
{
    private readonly AppDbContext _context;

    public EfContactMessageDal(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> GetContactCount()
    {
        return await _context.ContactMessages.CountAsync();
    }
}
