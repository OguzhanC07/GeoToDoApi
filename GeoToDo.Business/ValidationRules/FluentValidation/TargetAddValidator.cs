using FluentValidation;
using GeoToDo.DTO.DTOs.TargetDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.ValidationRules.FluentValidation
{
    public class TargetAddValidator : AbstractValidator<TargetAddDto>
    {
        public TargetAddValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name place can't be blank");
            RuleFor(I => I.SavedTime).NotEmpty().WithMessage("Time place can't be blank");
        }
    }
}
