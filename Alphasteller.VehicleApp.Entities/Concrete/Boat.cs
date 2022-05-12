using Alphasteller.VehicleApplication.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Entities.Concrete
{
    
    public class Boat:Vehicle,IEntity
    {      
        public int NumberOfPropellers { get; set; }
    }
}
