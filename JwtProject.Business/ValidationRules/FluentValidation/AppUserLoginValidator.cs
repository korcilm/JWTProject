using FluentValidation;
using JWTProject.Entities.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez");
        }
    }
}
