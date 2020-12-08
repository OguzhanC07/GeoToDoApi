using FluentValidation;
using GeoToDo.DTO.DTOs.AppUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.Email).NotEmpty().WithMessage("Email place can't be blank");
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Username can't be blank");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password can't be blank");
        }

    }
}
