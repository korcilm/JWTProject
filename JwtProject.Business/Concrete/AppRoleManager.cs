using JwtProject.Business.Interfaces;
using JWTProject.DataAccess.Interfaces;
using JWTProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.Concrete
{
    public class AppRoleManager:GenericManager<AppRole>, IAppRoleService
    {
        public AppRoleManager(IGenericDal<AppRole> genericDal):base(genericDal)
        {

        }
    }
}
