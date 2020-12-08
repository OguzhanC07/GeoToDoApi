using FluentValidation;
using GeoToDo.DTO.DTOs.ActivityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.ValidationRules.FluentValidation
{
    public class AddActivityValidator : AbstractValidator<AddActivityDto>
    {
        public AddActivityValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name can't be blank");
            RuleFor(I => I.SelectedTime).NotEmpty().WithMessage("Time can't be blank");
            RuleFor(I => I.AppUserId).NotEmpty().NotNull().WithMessage("Id can't be blank");
        }
    }
}
