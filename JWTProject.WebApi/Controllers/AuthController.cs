using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtProject.Business.Interfaces;
using JWTProject.Entities.DTOs.AppUserDtos;
using JWTProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        public AuthController(IJwtService jwtService, IAppUserService appUserService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }

        [HttpGet("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto userLoginDto)
        {
            var appUser = await _appUserService.FindByUserName(userLoginDto.UserName);
            if (appUser == null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
            else
            {
                if (await _appUserService.CheckPassword(userLoginDto))
                {
                    var token = _jwtService.GenerateJwt(appUser, null);
                    return Created("", token);
                }
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }
    }
}
