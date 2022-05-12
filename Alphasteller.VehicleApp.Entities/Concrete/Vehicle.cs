using Alphasteller.VehicleApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Entities.Concrete
{   
    public  class Vehicle:BaseEntity,IEntity
    {
        public  int Id { get; set; }
        public  string? Name { get; set; }       
        public  int Year { get; set; }
        public  int Km { get; set; }
        public  Brand Brand { get; set; }
        public  int BrandId { get; set; }
        public  Color Color { get; set; }
        public  int ColorId { get; set; }
    }
}
