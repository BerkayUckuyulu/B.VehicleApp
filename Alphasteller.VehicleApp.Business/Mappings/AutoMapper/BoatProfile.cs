using Alphasteller.VehicleApplication.Dtos.BoatDtos;
using Alphasteller.VehicleApplication.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Business.Mappings.AutoMapper
{
    public class BoatProfile:Profile
    {
        public BoatProfile()
        {
            CreateMap<Boat, BoatListDto>().ReverseMap();
        }
    }
}
