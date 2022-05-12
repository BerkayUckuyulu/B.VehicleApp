using Alphasteller.VehicleApplication.Dtos.ColorDtos;
using Alphasteller.VehicleApplication.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Business.Mappings.AutoMapper
{
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorListDto>().ReverseMap();
        }
    }
}
