using Eszi.Beadando.Server.Dtos.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Eszi.Beadando.Server
{
    public static class DependencyInjection
    {
        // Extenstion method
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfigSection = configuration.GetSection(nameof(JwtOptions));
            // Inject
            services.Configure<JwtOptions>(jwtConfigSection);
            // Use
            var jwtConfig = jwtConfigSection.Get<JwtOptions>() ?? new JwtOptions();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = jwtConfig?.Issuer,
                        ValidAudience = jwtConfig?.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig!.Key))
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
