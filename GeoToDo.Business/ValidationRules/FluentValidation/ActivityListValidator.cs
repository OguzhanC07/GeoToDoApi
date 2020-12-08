using FluentValidation;
using GeoToDo.DTO.DTOs.ActivityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.ValidationRules.FluentValidation
{
    public class ActivityListValidator : AbstractValidator<ActivityListDto>
    {
        public ActivityListValidator()
        {
            RuleFor(I => I.Id).NotEmpty().WithMessage("Id can't be blank");
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name can't be blank");
            RuleFor(I => I.SelectedTime).NotEmpty().WithMessage("Time can't be blank");
        }
    }
}
