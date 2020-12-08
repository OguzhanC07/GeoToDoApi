using FluentValidation;
using GeoToDo.DTO.DTOs.AppUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.ValidationRules.FluentValidation
{
    class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.EmailOrUserName).NotEmpty().WithMessage("Email or password can't be blank");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password can't be blank");
        }
    }
}
