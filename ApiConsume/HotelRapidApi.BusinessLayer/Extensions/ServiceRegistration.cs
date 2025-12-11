using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomService,RoomManager>();
            services.AddScoped<IServiceService,ServiceManager>();
            services.AddScoped<IStaffService,StaffManager>();
            services.AddScoped<ISubscribeService,SubscribeManager>();
            services.AddScoped<ITestimonialService,TestimonialManager>();
        }
    }
}
