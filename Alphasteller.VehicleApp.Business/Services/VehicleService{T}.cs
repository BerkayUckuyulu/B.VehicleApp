using Alphasteller.VehicleApplication.Business.Interfaces;
using Alphasteller.VehicleApplication.DataAccess.UnitOfWork;
using Alphasteller.VehicleApplication.Dtos.CarDtos;
using Alphasteller.VehicleApplication.Dtos.Interfaces;
using Alphasteller.VehicleApplication.Entities.Concrete;
using AutoMapper;
using Common.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Business.Services
{
    //Tüm Vehicle temelli classlarda kullanılabilir.Tek yapılması gereken ilgili Dtoların oluşturulması ve DependencyExtension'da gerekli
    //bağımlılıkların yazılması
    public class VehicleService<T,M> : IVehicleService<T,M> where T: IVehicleDto where M:Vehicle
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public VehicleService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<T>>> GetAll()
        {
            var data = _mapper.Map<List<T>>(await _uow.GetRepository<M>().GetAll());
            return new Response<List<T>>(ResponseType.Success, data);
        }

        public List<T> GetByColorId(int id)
        {
            var data=_mapper.Map<List<T>>(_uow.GetVehicleRepository<M>().GetAllByColorId(id));
            return data;
        }

        public List<T> GetByColorName(string colorName)
        {
            var data = _mapper.Map<List<T>>(_uow.GetVehicleRepository<M>().GetAllByColorName(colorName));
            return data;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data= _mapper.Map<T>(await _uow.GetVehicleRepository<M>().GetByIdAsync(id));
            
            return data;
        }

        //Burada Headlight propertysi Vehicle base classında tanımlanabilirdi. Bu sayede metot tüm Vehicle türdeki classlar için kullanılabilirdi.
        public async Task<CarListDto> HeadlightsById(int id)
        {
            var data=_uow.GetVehicleRepository<Car>().HeadlightsById(id);
            var result=_mapper.Map<CarListDto>(data);
            await _uow.SaveChanges();
            return result;
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _uow.GetRepository<M>().GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _uow.GetRepository<M>().Remove(removedEntity);
                await _uow.SaveChanges();

                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id}Bulunamadı.");

            }
        }
    }
}
