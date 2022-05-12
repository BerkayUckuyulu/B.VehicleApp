using Alphasteller.VehicleApplication.Dtos.Interfaces;
using Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Dtos.CarDtos
{
    public class CarUpdateDto:IDto,IVehicleDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public int NumberOfWheels { get; set; }
        public bool Headlight { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
    }
}
