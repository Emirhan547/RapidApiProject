using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.EntityFramework;
using HotelRapidApi.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DataAccessLayer.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessService(this IServiceCollection services)
        {
            services.AddScoped<IRoomDal, EfRoomDal>();
            services.AddScoped<IServicesDal, EfServiceDal>();
            services.AddScoped<IStaffDal, EfStaffDal>();
            services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IContactMessageDal, EfContactMessageDal>();
            services.AddScoped<IGuestDal, EfGuestDal>();
            services.AddScoped<ISendMessageDal, EfSendMessageDal>();
            services.AddScoped<IMessageCategoryDal, EfMessageCategoryDal>();
            services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();
        }
    }
}