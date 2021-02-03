using AutoMapper;
using GeoToDo.Business.Interfaces;
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
    public class ProfileController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public ProfileController(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _appUserService.GetByIdAsync(id);
            if (user!=null)
            {
                return Ok(_mapper.Map<AppUserEditDto>(user));
            }
            return NotFound(new { Error = "Böyle bir kullanıcı bulunamadı" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> UpdateUser(int id, AppUserEditDto model)
        {
            var user = await _appUserService.GetByIdAsync(id);
            var emailUser = await _appUserService.FindByEmail(model.Email);
            if (id!=model.Id)
            {
                return BadRequest("Id uyuşmazlığı");
            }
            else if (emailUser != null && user.Id!=emailUser.Id )
            {
                return BadRequest(new { Error = "Bu e-posta kullanılmaktadır.", ErrorType = "EMAIL_IS_ALREADY_IN_USE" });
            }
            else
            {
                user.Email = model.Email.ToLower();
                user.Surname = model.Surname;
                user.Name = model.Name;
                user.UserName = model.UserName.ToLower();
                await _appUserService.UpdateAsync(user);

                return NoContent();
            }
        }

        [HttpPut("[action]/{id}")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> ResetPassword(int id,AppUserResetPasswordDto model)
        {

            if (id!=model.Id)
            {
                return BadRequest("Id uyusmazligi");
            }

            var user = await _appUserService.GetByIdAsync(id);

            if (BCrypt.Net.BCrypt.Verify(model.OldPassword, user.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                await _appUserService.UpdateAsync(user);
                return Ok();
            }
            else
            {
                return BadRequest(new { Error = "Girdiğin şifre hatalı", ErrorType = "PASSWORD_IS_NOT_CORRECT" });
            }

            
            

        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _appUserService.GetByIdAsync(id);
            if (user!=null)
            {
                user.IsVisible = false;
                await _appUserService.UpdateAsync(user);
                return Ok();
            }
            return NotFound(new { Error = "Böyle bir kullanıcı bulunmamaktadır." });
        }
    }
}
