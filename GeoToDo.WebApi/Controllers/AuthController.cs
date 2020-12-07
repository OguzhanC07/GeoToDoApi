using AutoMapper;
using GeoToDo.Business.Interfaces;
using GeoToDo.Business.StringInfos;
using GeoToDo.DTO.DTOs.AppUserDto;
using GeoToDo.Entities.Concrete;
using GeoToDo.WebApi.CustomFilters;
using GeoToDo.WebApi.Models;
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
    public class AuthController : BaseController
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        public AuthController(IMapper mapper,IJwtService jwtService, IAppUserService appUserService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.CheckUserAsync(appUserLoginDto);
            if (user != null)
            {
                var roles = await _appUserService.GetRolesByEmailOrUserNameAsync(appUserLoginDto.EmailOrUserName);

                return Created("", _jwtService.GenerateJwt(user, roles));
            }
            else
            {
                return BadRequest("Username or password is wrong");
            }
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp([FromForm] AppUserAddDto model, [FromServices]IAppUserRoleService appUserRoleService,[FromServices]IAppRoleService appRoleService)
        {
            AppUserLoginDto appUserLoginDto = new AppUserLoginDto
            {
                EmailOrUserName = model.Email,
                Password = model.Password
            };
            var appUser = await _appUserService.CheckUserAsync(appUserLoginDto);
            if (appUser != null)
            {
                return BadRequest("Username or email taken, please try new username or email");
            }
            else
            {
                model.ImagePath = "default.jpg";
                await _appUserService.AddAsync(_mapper.Map<AppUser>(model));

                var user = await _appUserService.CheckUserAsync(appUserLoginDto);
                var role = await appRoleService.FindByNameAsync(RoleInfo.Member);

                await appUserRoleService.AddAsync(new AppUserRole
                {
                    AppRoleId = role.Id,
                    AppUserId = user.Id
                });

                return Created("", model);
            }
        }

        [HttpGet("[action]")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> GetActiveUser()
        {
            var user = await _appUserService.FindUserAsync(User.Identity.Name);
            var roles = await _appUserService.GetRolesByEmailOrUserNameAsync(user.UserName);

            AppUserDto appUserDto = new AppUserDto
            {
                Id = user.Id,
                FullName = user.Name + " " + user.SurName,
                UserName = user.UserName,
                Roles = roles.Select(I => I.Name).ToList()
            };

            return Ok(appUserDto);
        }
    }
}
