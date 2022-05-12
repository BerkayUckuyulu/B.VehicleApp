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
    public class BrandConfigurations :  IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.BrandName).IsRequired();
            builder.Property(x => x.BrandName).HasMaxLength(30);
            builder.HasMany(x => x.Vehicles).WithOne(x => x.Brand);        
        }
    }
}
