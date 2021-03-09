using JWTProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWTProject.Entities.DTOs.ProductDtos
{
    public class ProductUpdateDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
