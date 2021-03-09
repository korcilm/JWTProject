using JwtProject.Business.Interfaces;
using JWTProject.DataAccess.Interfaces;
using JWTProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.Concrete
{
    public class AppUserRoleManager:GenericManager<AppUserRole>, IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal):base(genericDal)
        {

        }
    }
}
