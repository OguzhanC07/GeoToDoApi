using AutoMapper;
using GeoToDo.Business.Interfaces;
using GeoToDo.DTO.DTOs.TargetDto;
using GeoToDo.Entities.Concrete;
using GeoToDo.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoToDo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetController : ControllerBase
    {
        private readonly ITargetService _targetService;
        private readonly IMapper _mapper;
        public TargetController(IMapper mapper, ITargetService targetService)
        {
            _mapper = mapper;
            _targetService = targetService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> GetAllByAppUserId(int id)
        {
            return Ok(_mapper.Map<List<TargetListDto>>(await _targetService.GetTargetsByAppUserId(id)));
        }

        [HttpGet("[action]/id")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<TargetListDto>(await _targetService.GetByIdAsync(id)));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> AddTarget(TargetAddDto targetAddDto)
        {
            await _targetService.AddAsync(_mapper.Map<Target>(targetAddDto));
            return Created("", targetAddDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> UpdateTarget(int id, [FromForm] TargetListDto targetListDto)
        {
            if (id != targetListDto.Id)
            {
                return BadRequest("Id is not correct");
            }
            else
            {
                var updatedTarget = await _targetService.GetByIdAsync(id);
                updatedTarget.Name = targetListDto.Name;
                updatedTarget.SavedTime = targetListDto.SavedTime;
                await _targetService.UpdateAsync(updatedTarget);
                return NoContent();
            }
        }

        [HttpPut("[action]/{id}")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> CompleteTarget(int id)
        {
            var target = await _targetService.GetByIdAsync(id);
            target.isAchieved = true;
            target.AchievedTime = DateTime.Now;
            await _targetService.UpdateAsync(target);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> DeleteTarget(int id)
        {
            await _targetService.RemoveAsync(await _targetService.GetByIdAsync(id));
            return NoContent();
        }
    }
}
