using Alphasteller.VehicleApplication.Dtos.CarDtos;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
   public  class CarCreateDtoValidator:AbstractValidator<CarCreateDto>
    {
        //Client tarafından server'a çok bir akış olmadığı için FluentValidation' göstermelik olarak 2 tane Dto'ya uyguladım.
        public CarCreateDtoValidator()
        {
            
            RuleFor(x => x.Year).NotEmpty();
        }       
    }
}
