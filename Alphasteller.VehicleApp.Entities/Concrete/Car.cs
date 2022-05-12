using Alphasteller.VehicleApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Entities.Concrete
{
    
    public class Car:Vehicle,IEntity
    {     
        public int NumberOfWheels { get; set; }
        public bool Headlight { get; set; }      
    }
}
