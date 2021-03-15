using FluentValidation;
using JwtProject.Business.Concrete;
using JwtProject.Business.Interfaces;
using JwtProject.Business.ValidationRules.FluentValidation;
using JWTProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using JWTProject.DataAccess.Interfaces;
using JWTProject.Entities.DTOs.AppUserDtos;
using JWTProject.Entities.DTOs.ProductDtos;
using Microsoft.Extensions.DependencyInjection;


namespace JwtProject.Business.Containers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            /* dependency injection */
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddScoped<IJwtService, JwtManager>();
            /* fluent validation */
            services.AddTransient<IValidator<ProductAddDto>, ProductAddValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();

        }
    }
}
