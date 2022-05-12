using Alphasteller.VehicleApplication.Dtos.CarDtos;
using Alphasteller.VehicleApplication.Dtos.Interfaces;
using Alphasteller.VehicleApplication.Entities.Concrete;
using Common.ResponseObjects;
using Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Business.Interfaces
{
    public interface IVehicleService<T,M> where T:IVehicleDto where M:Vehicle
    {
        //Tüm Vehicle temelli classlarda kullanılabilir.Tek yapılması gereken ilgili Dtoların oluşturulması ve DependencyExtension'da gerekli
        //bağımlılıkların yazılması
        Task<IResponse<List<T>>> GetAll();
        List<T> GetByColorName(string color);
        List<T> GetByColorId(int id);
        Task<T> GetByIdAsync(int id);
        Task<IResponse> Remove(int id);

        //Burada Headlight propertysi Vehicle base classında tanımlanabilirdi. Bu sayede metot tüm Vehicle türdeki classlar için kullanılabilirdi.
        Task<CarListDto> HeadlightsById(int id);
    }
}
