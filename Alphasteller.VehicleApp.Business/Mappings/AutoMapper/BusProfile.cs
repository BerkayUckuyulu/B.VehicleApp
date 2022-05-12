using Alphasteller.VehicleApplication.Dtos.BusDtos;
using Alphasteller.VehicleApplication.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Business.Mappings.AutoMapper
{
    public class BusProfile:Profile
    {
        public BusProfile()
        {
            CreateMap<Bus, BusListDto>().ReverseMap();
        }
    }
}
