using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JwtProject.Business.Interfaces;
using JwtProject.Business.StringInfos;
using JWTProject.Entities.Concrete;
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
        private readonly IMapper _mapper;
        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
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
                    var roles = await _appUserService.GetRolesByUserName(userLoginDto.UserName);
                    var token = _jwtService.GenerateJwt(appUser, roles);
                    return Created("", token);
                }
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto,
            [FromServices] IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var appUser= await _appUserService.FindByUserName(appUserAddDto.UserName);
            if (appUser != null)
            {
                return BadRequest($"{appUserAddDto.UserName} zaten alınmış");
            }
            await _appUserService.Add(_mapper.Map<AppUser>(appUserAddDto));
            var user = await _appUserService.FindByUserName(appUserAddDto.UserName);
            var role = await appRoleService.FindByName(RoleInfo.Member);
            await appUserRoleService.Add(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });
            return Created("", appUserAddDto);
        }
    }
}
