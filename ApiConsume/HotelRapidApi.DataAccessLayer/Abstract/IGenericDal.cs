using HotelRapidApi.EntityLayer.Entities.Common;

public interface IGenericDal<TEntity> where TEntity : BaseEntity
{
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
    Task<List<TEntity>> GetListAsync();
    Task<TEntity> GetByIdAsync(int id);
}
