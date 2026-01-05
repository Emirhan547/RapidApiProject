using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IAppUserService
    {
       Task <List<AppUser>> TUserListWithWorkLocation();
        Task<List<AppUser>> TUsersListWithWorkLocations();
        Task<int> TAppUserCount();
        Task <List<AppUser>> GetListAsync();
    }
}
