using Alphasteller.VehicleApplication.Business.Interfaces;
using Alphasteller.VehicleApplication.Business.Mappings.AutoMapper;
using Alphasteller.VehicleApplication.Business.Services;
using Alphasteller.VehicleApplication.DataAccess.Contexts;
using Alphasteller.VehicleApplication.DataAccess.UnitOfWork;
using Alphasteller.VehicleApplication.Dtos.CarDtos;
using AutoMapper;
using Business.Interfaces;
using Business.Mappings.AutoMapper;
using Business.Services;
using Business.ValidationRules;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Business.DependencyResolvers
{
    public static class DependencyExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<VehicleContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\mssqllocaldb;database=B.AlphastellerVehicleAppDB;integrated security=true;");
            });

            //Bağımlıklıkların eklenmesi.
            services.AddScoped<IUow, Uow>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IColorService, ColorService>();

            services.AddScoped(typeof(IVehicleService<,>), typeof(VehicleService<,>));

            services.AddTransient<IValidator<CarCreateDto>, CarCreateDtoValidator>();
            services.AddTransient<IValidator<CarUpdateDto>, CarUpdateDtoValidator>();

            //AutoMapper'ın eklenmesi.
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new CarProfile());
                opt.AddProfile(new ColorProfile());
                opt.AddProfile(new BusProfile());
                opt.AddProfile(new BoatProfile());

            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
