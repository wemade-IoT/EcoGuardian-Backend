using EcoGuardian_Backend.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using EcoGuardian_Backend.Shared.Application.IOC;
using EcoGuardian_Backend.Shared.Infrastructure.IOC;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Interfaces.IOC;
using EcoGuardian_Backend.Shared.Application.Internal.EventHandler;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddInfrastructureDependencies(builder, configuration);
builder.Services.AddApplicationDependencies();
builder.Services.AddInterfaceDependencies(builder);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(9080); 
});



var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    services.OnStart();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.MapControllers();
app.UseRequestAuthorization();

app.Run();

