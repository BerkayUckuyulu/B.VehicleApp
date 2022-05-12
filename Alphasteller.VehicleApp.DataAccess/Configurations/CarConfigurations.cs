using Alphasteller.VehicleApplication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.DataAccess.Configurations
{
    public class CarConfigurations :IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.NumberOfWheels).IsRequired();
            builder.Property(x => x.Headlight).IsRequired();          
        }
    }
}
