using Alphasteller.VehicleApplication.Entities.Concrete;
using Common.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.DataAccess.Interfaces
{
    //Sadece Vehicle'dan türeyen classlar için.
    public interface IVehicleRepository<T> where T:Vehicle 
    {
         List<T> GetAllByColorName(string colorName);
         List<T> GetAllByColorId(int id);
        Task<T> GetByIdAsync(int id);

        //Burada Headlight propertysi Vehicle base classında tanımlanabilirdi. Bu sayede metot tüm Vehicle türdeki classlar için kullanılabilirdi.
        Car HeadlightsById(int Id);

    }
}
