using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DataAccessLayer.Abstract
{
    public interface IAppUserDal
    {
        Task<List<AppUser>> UserListWithLocation();
        Task<List<AppUser>>UserListWithWorkLocations();
        Task<int> AppUserCount();
        Task<List<AppUser>> GetListAsync();
    }
}
