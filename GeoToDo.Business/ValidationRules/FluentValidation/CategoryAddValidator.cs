using FluentValidation;
using GeoToDo.DTO.DTOs.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name can't be blank");
            RuleFor(I => I.AppUserId).NotEmpty().NotNull().WithMessage("Id can't be blank");
        }
    }
}
