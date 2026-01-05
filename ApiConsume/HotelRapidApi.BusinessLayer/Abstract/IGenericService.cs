using HotelRapidApi.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IGenericService<TResult, TCreate, TUpdate>
    {
        Task CreateAsync(TCreate create);
        Task UpdateAsync(TUpdate update);
        Task DeleteAsync(int id);
        Task<List<TResult>> GetListAsync();
        Task<TResult> GetByIdAsync(int id);
    }


}

