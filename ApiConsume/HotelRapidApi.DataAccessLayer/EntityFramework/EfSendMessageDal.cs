using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.DataAccessLayer.Repositories;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DataAccessLayer.EntityFramework
{
    public class EfSendMessageDal : GenericRepository<SendMessage>, ISendMessageDal
    {
        private readonly AppDbContext _context;
        public EfSendMessageDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task <int> GetSendMessageCount()
        {
            return await _context.ContactMessages.CountAsync();
        }
    }
}
