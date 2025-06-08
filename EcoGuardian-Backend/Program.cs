using EcoGuardian_Backend.IAM.Application.Internal.CommandServices;
using EcoGuardian_Backend.IAM.Application.Internal.OutboundServices;
using EcoGuardian_Backend.IAM.Application.Internal.QueryServices;
using EcoGuardian_Backend.IAM.Domain.Respositories;
using EcoGuardian_Backend.IAM.Domain.Services;
using EcoGuardian_Backend.IAM.Infrastructure.Hashing.BCrypt.Services;
using EcoGuardian_Backend.IAM.Infrastructure.Persistence.EFC.Respositories;
using EcoGuardian_Backend.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using EcoGuardian_Backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using EcoGuardian_Backend.IAM.Infrastructure.Tokens.JWT.Services;
using EcoGuardian_Backend.IAM.Interfaces.ACL;
using EcoGuardian_Backend.IAM.Interfaces.ACL.Service;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.EventHandlers;
using EcoGuardian_Backend.Shared.Application.IOC;
using EcoGuardian_Backend.Shared.Infrastructure.IOC;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Interfaces.IOC;
using EcoGuardian_Backend.IAM.Domain.Model.Entities;
using EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureDependencies(builder, configuration);
builder.Services.AddApplicationDependencies();
builder.Services.AddInterfaceDependencies(builder, configuration);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(9080); 
});


builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<ISeedUserRoleCommandService, SeedUserRoleCommandService>();


// IAM Bounded Context Injection Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();



var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    // Seeder de roles usando enum EUserRoles
    if (!context.Set<UserRole>().Any())
    {
        var roles = Enum.GetNames(typeof(EUserRoles))
            .Select(role => new UserRole(role));
        context.Set<UserRole>().AddRange(roles);
        context.SaveChanges();
    }
    services.On();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRequestAuthorization();
app.UseCors("AllowAllOrigins");


app.Run();
