using JwtProject.Business.Interfaces;
using JWTProject.DataAccess.Interfaces;
using JWTProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.Concrete
{
    public class AppUserManager: GenericManager<AppUser>, IAppUserService
    {
        public AppUserManager(IGenericDal<AppUser> genericDal):base(genericDal)
        {

        }
    }
}
