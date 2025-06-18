using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.EventHandlers;
using EcoGuardian_Backend.Shared.Application.IOC;
using EcoGuardian_Backend.Shared.Infrastructure.IOC;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Interfaces.IOC;

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


var app = builder.Build();





using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
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
app.UseCors("AllowAllOrigins");


app.Run();

