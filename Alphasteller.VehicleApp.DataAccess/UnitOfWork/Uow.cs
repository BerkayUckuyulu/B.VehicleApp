using Alphasteller.VehicleApplication.DataAccess.Contexts;
using Alphasteller.VehicleApplication.DataAccess.Interfaces;
using Alphasteller.VehicleApplication.DataAccess.Repositories;
using Alphasteller.VehicleApplication.Entities.Abstract;
using Alphasteller.VehicleApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly VehicleContext _context;

        public Uow(VehicleContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }
        public IVehicleRepository<T> GetVehicleRepository<T>() where T:Vehicle
        {
            return new VehicleRepository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
