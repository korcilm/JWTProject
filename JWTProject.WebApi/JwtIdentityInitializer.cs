using JwtProject.Business.Interfaces;
using JwtProject.Business.StringInfos;
using JWTProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTProject.WebApi
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService )
        {
            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);
            if (adminRole==null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }
            var memberRole = await appRoleService.FindByName(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByUserName("admin");
            if (adminUser == null)
            {
                await appUserService.Add(new AppUser
                {
                    FullName = "Muhammet Korçil",
                    UserName = "admin",
                    Password = "1"
                });
                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var user = await appUserService.FindByUserName("admin");
                await appUserRoleService.Add(new AppUserRole
                {
                    AppUserId = user.Id,
                    AppRoleId = role.Id
                });
            }
        }
    }
}
