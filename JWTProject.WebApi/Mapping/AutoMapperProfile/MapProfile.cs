using AutoMapper;
using JWTProject.Entities.Concrete;
using JWTProject.Entities.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTProject.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
        }
    }
}
