using JWTProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWTProject.Entities.DTOs.AppUserDtos
{
    public class AppUserLoginDto :IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
