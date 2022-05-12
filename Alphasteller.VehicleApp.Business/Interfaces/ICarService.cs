using Alphasteller.VehicleApplication.Dtos.CarDtos;
using Common.ResponseObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICarService
    {
        //CarService'i yapmama gerek yoktu,içerisindeki metotları Generic olan VehicleService'de yazsam tüm Vehicle kökenli classlarda kullanabilirdim.
        //Ancak hem CRUD işlemlerini Response yapısı kullanarak daha sade bir şekilde bu classa yazmak istedim hem de ileride Car nesnesine özgü işlemler olduğunda buraya hızlıca yazabilmek istedim.

        Task<IResponse<List<CarListDto>>> GetAll();
        Task<IResponse<CarCreateDto>> Create(CarCreateDto carCreateDto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        List<CarListDto> GetByColorName(string color);

        Task<IResponse> Remove(int id);
        Task<IResponse<CarUpdateDto>> Update(CarUpdateDto carUpdateDto);
        

        
    }
}
