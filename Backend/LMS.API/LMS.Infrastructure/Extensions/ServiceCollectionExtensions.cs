using LMS.Application;
using LMS.Application.Features.Services;
using LMS.Application.Interfaces;
using LMS.Domain.Repositories;
using LMS.Infrastructure.Auth;
using LMS.Infrastructure.Repositories;
using LMS.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtSettings>(config.GetSection("JwtSettings"));
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            var jwtSettings = config.GetSection("JwtSettings").Get<JwtSettings>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization();

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleManagementRepository, RoleRepository>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IRoleManagementService, RoleManagementService>();

            return services;
        }
        public static IServiceCollection AddUtilityDI(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            services.AddScoped<IApplicationDBContext, ApplicationDBContext>();
            services.AddScoped<IPdfReportService, PdfReportService>();
            return services;
        }
    }
}
