using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.DataAccessLayer.Repositories;
using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DataAccessLayer.EntityFramework
{
    public class EfMessageCategoryDal : GenericRepository<MessageCategory>, IMessageCategoryDal
    {
        public EfMessageCategoryDal(AppDbContext context) : base(context)
        {
        }
    }
}
