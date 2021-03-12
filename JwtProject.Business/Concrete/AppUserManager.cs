using JwtProject.Business.Interfaces;
using JWTProject.DataAccess.Interfaces;
using JWTProject.Entities.Concrete;
using JWTProject.Entities.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JwtProject.Business.Concrete
{
    public class AppUserManager: GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) :base(genericDal)
        {
            _appUserDal = appUserDal;
        }

        public async Task<bool> CheckPassword(AppUserLoginDto userLoginDto)
        {
            var appUser = await _appUserDal.GetByFilter(I => I.UserName == userLoginDto.UserName);
            return appUser.Password == userLoginDto.Password ? true : false;
        }

        public async Task<AppUser> FindByUserName(string userName)
        {
            return await _appUserDal.GetByFilter(I => I.UserName == userName);
        }

        public async Task<List<AppRole>> GetRolesByUserName(string userName)
        {
            return await _appUserDal.GetRolesByUserName(userName);
        }
    }
}
