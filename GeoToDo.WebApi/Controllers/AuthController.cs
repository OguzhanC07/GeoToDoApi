using AutoMapper;
using GeoToDo.Business.Interfaces;
using GeoToDo.Business.StringInfos;
using GeoToDo.DTO.DTOs.AppUserDto;
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
    public class AuthController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService,IAppUserService appUserService,IMapper mapper)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto model)
        {
            var user = await _appUserService.FindByEmail(model.Email);

            if (user !=null && BCrypt.Net.BCrypt.Verify(model.Password,user.Password))
            {
                var roles = await _appUserService.GetRolesByEmail(model.Email);
                var token = _jwtService.GenerateJwt(user, roles);
                return Created("", new { token.Token, user.Id, expiresIn = 30 * 60 });
            }
            return BadRequest(new { Error="Kullanıcı adı veya şifre yanlış." , ErrorType="EMAIL_OR_PASSWORD_WRONG"});
        }


        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto, [FromServices] IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByEmail(appUserAddDto.Email);

            if (appUser != null)
            {
                return BadRequest(new { Error = $"{appUserAddDto.Email} alınmıştır. Farklı bir e-posta dene", ErrorType = "EMAIL_IS_ALREADY_IN_USE" });
            }

            appUserAddDto.Password = BCrypt.Net.BCrypt.HashPassword(appUserAddDto.Password);
            appUserAddDto.ImagePath = "default.jpg";

            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));

            var user = await _appUserService.FindByEmail(appUserAddDto.Email);
            var role = await appRoleService.FindByNameAsync(RoleInfo.Member);

            await appUserRoleService.AddAsync(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });

            var newUser = await _appUserService.FindByEmail(appUserAddDto.Email);
            var roles = await _appUserService.GetRolesByEmail(appUserAddDto.Email);
            var token = _jwtService.GenerateJwt(newUser, roles);

            return Created("", new { token.Token, newUser.Id, expiresIn=30*60});
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> GetActiveUser()
        {
            var user = await _appUserService.FindByEmail(User.Identity.Name);
            var roles = await _appUserService.GetRolesByEmail(user.Email);

            AppUserDto appUserDto = new AppUserDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles.Select(I => I.Name).ToList()
            };

            return Ok(appUserDto);
        }
    }
}
