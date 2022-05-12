using Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Dtos.ColorDtos
{
    public class ColorListDto:IDto
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
