using Alphasteller.VehicleApplication.DataAccess.Configurations;
using Alphasteller.VehicleApplication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.DataAccess.Contexts
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfigurations());
            modelBuilder.ApplyConfiguration(new BusConfigurations());
            modelBuilder.ApplyConfiguration(new BoatConfigurations());
            modelBuilder.ApplyConfiguration(new ColorConfigurations());
            modelBuilder.ApplyConfiguration(new VehicleConfigurations());
            modelBuilder.ApplyConfiguration(new BrandConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }

}
