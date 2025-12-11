using HotelRapidApi.EntityLayer.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DataAccessLayer.Interceptors
{
    public class AuditDbContextInterceptor:SaveChangesInterceptor
    {
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            foreach(var entry in eventData.Context.ChangeTracker.Entries())
            {
                if(entry.Entity is not BaseEntity baseEntity)
                {
                    continue;
                }
                if (entry.State is not EntityState.Added and not Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    continue;
                }
                if(entry.State is EntityState.Added)
                {
                    eventData.Context.Entry(baseEntity).Property(x => x.CreatedDate).CurrentValue = DateTime.Now;
                    eventData.Context.Entry(baseEntity).Property(x => x.UpdatedDate).IsModified = false;
                }
                if (entry.State is EntityState.Modified)
                {
                    eventData.Context.Entry(baseEntity).Property(x => x.UpdatedDate).CurrentValue = DateTime.Now;
                    eventData.Context.Entry(baseEntity).Property(x => x.UpdatedDate).IsModified = false;
                }

            }

            return base.SavedChanges(eventData, result);
        }
    }
}
