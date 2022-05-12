using Alphasteller.VehicleApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Entities.Concrete
{
    public class Color:BaseEntity,IEntity
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
