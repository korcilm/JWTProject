using FluentValidation;
using JWTProject.Entities.Concrete;
using JWTProject.Entities.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateValidator: AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue);
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        }
    }
}
