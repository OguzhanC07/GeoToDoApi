using GeoToDo.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoToDo.WebApi.CustomFilters
{
    public class ValidId<T> : IActionFilter where T : class,new()
    {
        private readonly IGenericService<T> _genericService;
        public ValidId(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();

            if (dictionary.Value==null)
            {
                context.Result = new NotFoundObjectResult("Wrong entry type");
            }
            else
            {
                var id = int.Parse(dictionary.Value.ToString());

                var entity = _genericService.GetByIdAsync(id).Result;

                if (entity== null)
                {
                    context.Result = new NotFoundObjectResult($"We don't have records like this {id}");
                }
            }
        }
    }
}
