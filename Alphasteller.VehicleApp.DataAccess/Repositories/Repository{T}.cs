using Alphasteller.VehicleApplication.DataAccess.Contexts;
using Alphasteller.VehicleApplication.DataAccess.Interfaces;
using Alphasteller.VehicleApplication.Entities.Abstract;
using Alphasteller.VehicleApplication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.DataAccess.Repositories
{
    //Color,Brand ve Vehicles için yazılmış Generic metotlar.
    public class Repository<T> : IRepository<T> where T:BaseEntity
    {
        private readonly VehicleContext _context;

        public Repository(VehicleContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            
                    
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();         
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter) : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> Find(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {


            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchangedEntity)
        {

            _context.Entry(unchangedEntity).CurrentValues.SetValues(entity);
        }
      
    }
}
