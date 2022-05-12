using Alphasteller.VehicleApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Entities.Concrete
{
    public class Brand: BaseEntity, IEntity
    {      
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public List<Vehicle> Vehicles { get; set; }

    }
}
