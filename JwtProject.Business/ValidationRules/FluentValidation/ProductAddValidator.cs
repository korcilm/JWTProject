using FluentValidation;
using JWTProject.Entities.DTOs.ProductDtos;

namespace JwtProject.Business.ValidationRules.FluentValidation
{
    public class ProductAddValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        }
    }
}
