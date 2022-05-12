using Alphasteller.VehicleApplication.Business.Interfaces;
using Alphasteller.VehicleApplication.Dtos.CarDtos;
using Alphasteller.VehicleApplication.Dtos.ColorDtos;
using Alphasteller.VehicleApplication.Entities.Concrete;
using Business.Interfaces;
using Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IVehicleService<CarCreateDto,Car> _vehicleCarCreateService;
        private readonly IVehicleService<CarListDto,Car> _vehicleCarListService;
        
        private readonly ICarService _carService;
        private readonly IColorService _colorService;

        public CarsController(ICarService carService, IColorService colorService, IVehicleService<CarCreateDto, Car> vehicleCarCreateService, IVehicleService<CarListDto, Car> vehicleCarListService)
        {
            _carService = carService;
            _colorService = colorService;
            _vehicleCarCreateService = vehicleCarCreateService;
            _vehicleCarListService = vehicleCarListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var response=await _vehicleCarListService.GetAll();           
            return Ok(response.Data);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> HeadlightById(int id)
        {
           var data = await _vehicleCarListService.GetByIdAsync(id);
            if (data!=null && data.Headlight==false)
            {
                await _vehicleCarListService.HeadlightsById(id);
                return Ok("Farlar yandı.");
            }
            if (data!=null && data.Headlight==true)
            {
                await _vehicleCarListService.HeadlightsById(id);
                return Ok("Farlar kapandı.");
            }
            else
            {
                return NotFound($"{id}'ye ait araç bulunamadı.");
            }                                
        }
       
        [HttpGet("{colorName}")]
        public async Task<IActionResult> GetCarsByColorName(string colorName)
        {
           var colors=await _colorService.GetAll();
           var color= colors.Data.SingleOrDefault(x=>x.ColorName==colorName);
            if (color!=null)
            {
                var data = _vehicleCarListService.GetByColorName(colorName);
                return Ok(data);
            }
            else
            {
                return NotFound($"{colorName} adında renk bulunamadı.");
            }          
        }

        [HttpGet("getirColor/{id}")]
        public IActionResult GetCarsByColorId(int id)
        {
            var data = _vehicleCarListService.GetByColorId(id);
            return Ok(data);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var result = await _carService.Remove(id);
            if (result.ResponseType == ResponseType.Success)
            {
                return Ok("Araba Silindi.");
            }
            else
            {
                return NotFound("Silme İşlemi Başarısız");
            }

        }
        [HttpPost]
        public IActionResult Create(CarCreateDto carCreateDto)
        {
            if (ModelState.IsValid)
            {
                _carService.Create(carCreateDto);
                return Created(string.Empty, carCreateDto);
            }
            else
            {
                var error = "Ekleme Başarısız";
                return BadRequest(error);
            }
        }

        

    } 
}
