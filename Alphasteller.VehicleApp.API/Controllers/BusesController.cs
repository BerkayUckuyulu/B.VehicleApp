using Alphasteller.VehicleApplication.Business.Interfaces;
using Alphasteller.VehicleApplication.Dtos.BusDtos;
using Alphasteller.VehicleApplication.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly IVehicleService<BusListDto, Bus> _vehicleBusListService; 
        private readonly IColorService _colorService;

        public BusesController(IColorService colorService, IVehicleService<BusListDto, Bus> vehicleBusListService)
        {
            _colorService = colorService;
            _vehicleBusListService = vehicleBusListService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBus()
        {
            var response = await _vehicleBusListService.GetAll();
            return Ok(response.Data);
        }       

        [HttpGet("{colorName}")]
        public async Task<IActionResult> GetBusesByColorName(string colorName)
        {
            var colors = await _colorService.GetAll();
            var color = colors.Data.SingleOrDefault(x => x.ColorName == colorName);
            if (color != null)
            {
                var data = _vehicleBusListService.GetByColorName(colorName);
                return Ok(data);
            }
            else
            {
                return NotFound($"{colorName} adında renk bulunamadı.");
            }
            
        }

        [HttpGet("getirColor/{id}")]
        public IActionResult GetBusesByColorId(int id)
        {
            var data = _vehicleBusListService.GetByColorId(id);
            return Ok(data);

        }
        
    }
}
