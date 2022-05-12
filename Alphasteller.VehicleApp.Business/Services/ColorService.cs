using Alphasteller.VehicleApplication.Business.Interfaces;
using Alphasteller.VehicleApplication.DataAccess.UnitOfWork;
using Alphasteller.VehicleApplication.Dtos.ColorDtos;
using Alphasteller.VehicleApplication.Entities.Concrete;
using AutoMapper;
using Common.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Business.Services
{
    // ColorService Generic hale getirilerek ileride yazılması gereken BrandService için de kullanılabilir.
    public class ColorService : IColorService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public ColorService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<ColorListDto>>> GetAll()
        {
           var data= _mapper.Map<List<ColorListDto>>(await _uow.GetRepository<Color>().GetAll());
            return new Response<List<ColorListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetByColorName<IDto>(string colorName)
        {
            var color = await _uow.GetRepository<Color>().GetByFilter(x => x.ColorName == colorName);
            var data = _mapper.Map<IDto>(color);
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, " Bulunamadı.");
            }
            else
                return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var color = await _uow.GetRepository<Color>().GetByFilter(x => x.ColorId == id);
            var data = _mapper.Map<IDto>(color);
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, " Bulunamadı.");
            }
            else
                return new Response<IDto>(ResponseType.Success, data);
        }
    }
}
