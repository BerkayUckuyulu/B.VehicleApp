using Alphasteller.VehicleApplication.DataAccess.UnitOfWork;
using Alphasteller.VehicleApplication.Dtos.CarDtos;
using Alphasteller.VehicleApplication.Entities.Concrete;
using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Business.ValidationRules;
using Common.ResponseObjects;


using Dtos.Interfaces;


using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CarService : ICarService
    {
        //CarService'i yapmama gerek yoktu,içerisindeki metotları Generic olan VehicleService'de yazsam tüm Vehicle kökenli classlarda kullanabilirdim.
        //Ancak hem CRUD işlemlerini Response yapısı kullanarak daha sade bir şekilde bu classa yazmak istedim hem de ileride Car nesnesine özgü işlemler olduğunda buraya hızlıca yazabilmek istedim.

        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CarCreateDto> _createDtoValidator;
        private readonly IValidator<CarUpdateDto> _updateDtoValidator;

        public CarService(IUow uow, IMapper mapper, IValidator<CarCreateDto> createDto, IValidator<CarUpdateDto> updateDto)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDto;
            _updateDtoValidator = updateDto;
        }

        public async Task<IResponse<CarCreateDto>> Create(CarCreateDto carCreateDto)
        {
            var validationResult = _createDtoValidator.Validate(carCreateDto);


            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Car>().Create(_mapper.Map<Car>(carCreateDto));
                await _uow.SaveChanges();
                return new Response<CarCreateDto>(ResponseType.Success, carCreateDto);
            }
            else
            {             
                return new Response<CarCreateDto>(ResponseType.ValidationError, carCreateDto, validationResult.ConvertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<CarListDto>>> GetAll()
        {         
            var data = _mapper.Map<List<CarListDto>>(await _uow.GetRepository<Car>().GetAll());
            return new Response<List<CarListDto>>(ResponseType.Success, data);
        }

        public List<CarListDto> GetByColorName(string colorName)
        {
           var data=_mapper.Map<List<CarListDto>>(_uow.GetVehicleRepository<Car>().GetAllByColorName(colorName));
            return data;
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var car = await _uow.GetRepository<Car>().GetByFilter(x => x.Id == id);
           
            var data = _mapper.Map<IDto>(car);
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} Bulunamadı.");
            }
            else
                return new Response<IDto>(ResponseType.Success, data);
        }


        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _uow.GetRepository<Car>().GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _uow.GetRepository<Car>().Remove(removedEntity);
                await _uow.SaveChanges();

                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id}Bulunamadı.");

            }


        }

        public async Task<IResponse<CarUpdateDto>> Update(CarUpdateDto carUpdateDto)
        {
            var validateResult = _updateDtoValidator.Validate(carUpdateDto);

            if (validateResult.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Car>().Find(carUpdateDto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Car>().Update(_mapper.Map<Car>(carUpdateDto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<CarUpdateDto>(ResponseType.Success, carUpdateDto);
                }
                return new Response<CarUpdateDto>(ResponseType.NotFound, $"{carUpdateDto.Id} bulunamadı.");


            }
            else
            {
                return new Response<CarUpdateDto>(ResponseType.ValidationError, carUpdateDto, validateResult.ConvertToCustomValidationError());
            }          

        }
    }
}
