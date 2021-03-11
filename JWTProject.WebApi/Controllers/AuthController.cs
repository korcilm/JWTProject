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

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("[action]")]
        [ValidModel]
        public IActionResult SignIn(AppUserLoginDto userLoginDto)
        {
            return Created("", "");
        }
    }
}
