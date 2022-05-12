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
    
    public class VehicleConfigurations : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {                    
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.HasOne(x => x.Brand).WithMany(x => x.Vehicles).HasForeignKey(x => x.BrandId);
            builder.HasOne(x => x.Color).WithMany(x => x.Vehicles).HasForeignKey(x => x.ColorId);         
        }
    }
}
