using Alphasteller.VehicleApplication.DataAccess.Interfaces;
using Alphasteller.VehicleApplication.Entities.Abstract;
using Alphasteller.VehicleApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        IVehicleRepository<T> GetVehicleRepository<T>() where T:Vehicle;

        Task SaveChanges();
    }
}
