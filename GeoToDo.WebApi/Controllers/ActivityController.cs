﻿using AutoMapper;
using GeoToDo.Business.Interfaces;
using GeoToDo.DTO.DTOs.ActivityDto;
using GeoToDo.Entities.Concrete;
using GeoToDo.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GeoToDo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;
        public ActivityController(IMapper mapper, IActivityService activityService)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> GetActivityByAppUserId(int id)
        {
            return Ok(_mapper.Map<List<ActivityListDto>>(await _activityService.GetActivitiesByAppUserIdAsync(id)));
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            return Ok(_mapper.Map<ActivityListDto>(await _activityService.GetByIdAsync(id)));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> AddActivity(AddActivityDto addActivityDto)
        {
            await _activityService.AddAsync(_mapper.Map<Activity>(addActivityDto));
            return Created("", addActivityDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Member")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Activity>))]
        public async Task<IActionResult> UpdateActivity(int id, ActivityListDto activityListDto)
        {
            if (activityListDto.Id == id)
            {
                await _activityService.UpdateAsync(_mapper.Map<Activity>(activityListDto));
                return NoContent();
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _activityService.GetByIdAsync(id);
            activity.IsVisible = false;
            await _activityService.UpdateAsync(activity);
            return NoContent();
        }


        [HttpPut("[action]/{id}")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> CompleteActivity(int id)
        {
            var activity = await _activityService.GetByIdAsync(id);
            activity.IsCompleted = true;
            await _activityService.UpdateAsync(activity);
            return NoContent();
        }

        

    }
}
