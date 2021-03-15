using FluentValidation;
using JWTProject.Entities.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator:AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez");
            RuleFor(I => I.FullName).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez");
        }
    }
}
