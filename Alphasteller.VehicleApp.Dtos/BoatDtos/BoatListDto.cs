using Alphasteller.VehicleApplication.Dtos.Interfaces;
using Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Dtos.BoatDtos
{
    public class BoatListDto:IVehicleDto,IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int NumberOfPropellers { get; set; }
    }
}
