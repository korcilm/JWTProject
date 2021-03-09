using JwtProject.Business.Interfaces;
using JWTProject.DataAccess.Interfaces;
using JWTProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.Concrete
{
    public class ProductManager:GenericManager<Product>, IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal):base(genericDal)
        {

        }
    }
}
