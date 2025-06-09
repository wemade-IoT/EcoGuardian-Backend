using EcoGuardian_Backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using EcoGuardian_Backend.Shared.Interfaces.ASP.Configuration;

namespace EcoGuardian_Backend.Shared.Interfaces.IOC;

public static class InterfaceDependencyContainer
{
    public static IServiceCollection AddInterfaceDependencies(this IServiceCollection services, WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
        return services;
    }
}