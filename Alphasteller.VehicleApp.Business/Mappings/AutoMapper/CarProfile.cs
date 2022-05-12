using Alphasteller.VehicleApplication.Dtos.CarDtos;
using Alphasteller.VehicleApplication.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings.AutoMapper
{
    public class CarProfile:Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarListDto>().ReverseMap();
            CreateMap<Car, CarCreateDto>().ReverseMap();
            CreateMap<Car, CarUpdateDto>().ReverseMap();
            CreateMap<CarListDto, CarUpdateDto>().ReverseMap();
        }
    }
}
