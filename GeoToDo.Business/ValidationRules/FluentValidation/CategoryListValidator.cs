using FluentValidation;
using GeoToDo.DTO.DTOs.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.ValidationRules.FluentValidation
{
    public class CategoryListValidator : AbstractValidator<CategoryListDto>
    {
        public CategoryListValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name can't be blank");
        }
    }
}
