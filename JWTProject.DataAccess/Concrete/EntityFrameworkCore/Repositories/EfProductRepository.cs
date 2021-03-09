﻿using JWTProject.DataAccess.Interfaces;
using JWTProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWTProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfProductRepository:EfGenericRepository<Product>,IProductDal
    {
    }
}
