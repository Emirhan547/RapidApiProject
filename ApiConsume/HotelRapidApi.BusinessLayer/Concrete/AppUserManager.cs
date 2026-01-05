using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class AppUserManager (IAppUserDal _appUserDal): IAppUserService
    {
        public async Task<List<AppUser>> GetListAsync()
        {
            return await _appUserDal.GetListAsync();
        }

        public async Task<int> TAppUserCount()
        {
           return await _appUserDal.AppUserCount();
        }

        public async Task<List<AppUser>> TUserListWithWorkLocation()
        {
            return await _appUserDal.UserListWithWorkLocations();
        }

        public async Task<List<AppUser>> TUsersListWithWorkLocations()
        {
            return await _appUserDal.UserListWithWorkLocations();
        }
    }
}
