using Alphasteller.VehicleApplication.Business.Interfaces;
using Alphasteller.VehicleApplication.Dtos.BoatDtos;
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
    public class BoatsController : ControllerBase
    {
        private readonly IVehicleService<BoatListDto, Boat> _vehicleBoatListService;
        private readonly IColorService _colorService;

        public BoatsController(IColorService colorService, IVehicleService<BoatListDto, Boat> vehicleBoatListService)
        {
            _colorService = colorService;
            _vehicleBoatListService = vehicleBoatListService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBoat()
        {
            var response = await _vehicleBoatListService.GetAll();
            return Ok(response.Data);
        }

        [HttpGet("{colorName}")]
        public async Task<IActionResult> GetBoatsByColorName(string colorName)
        {
            var colors = await _colorService.GetAll();
            var color = colors.Data.SingleOrDefault(x => x.ColorName == colorName);
            if (color != null)
            {
                var data = _vehicleBoatListService.GetByColorName(colorName);
                return Ok(data);
            }
            else
            {
                return NotFound($"{colorName} adında renk bulunamadı.");
            }           
        }
        [HttpGet("getirColor/{id}")]
        public IActionResult GetBoatsByColorId(int id)
        {
            var data = _vehicleBoatListService.GetByColorId(id);
            return Ok(data);

        }
    }
}
