using JWTProject.Entities.Concrete;
using JWTProject.Entities.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JwtProject.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserName(string userName);
        Task<bool> CheckPassword(AppUserLoginDto userLoginDto);
        Task<List<AppRole>> GetRolesByUserName(string userName);
    }
}
