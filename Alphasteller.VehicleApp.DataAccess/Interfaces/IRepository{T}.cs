using Alphasteller.VehicleApplication.Entities.Abstract;
using Alphasteller.VehicleApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.DataAccess.Interfaces
{
    //Color,Brand ve Vehicles için yazılmış Generic metotlar.
    public interface IRepository<T> where T:BaseEntity
    {
        Task Create(T entity);
        Task<List<T>> GetAll();
        Task<T> Find(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);       
        void Remove(T entity);
        void Update(T entity, T unchangedEntity);
        IQueryable<T> GetQuery();
    }
}
