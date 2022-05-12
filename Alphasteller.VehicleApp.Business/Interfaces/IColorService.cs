using Alphasteller.VehicleApplication.Dtos.ColorDtos;
using Common.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphasteller.VehicleApplication.Business.Interfaces
{
    public interface IColorService
    {   
        // ColorService Generic hale getirilerek ileride yazılması gereken BrandService için de kullanılabilir.
        Task<IResponse<List<ColorListDto>>> GetAll();
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse<IDto>> GetByColorName<IDto>(string colorName);
    }
}
