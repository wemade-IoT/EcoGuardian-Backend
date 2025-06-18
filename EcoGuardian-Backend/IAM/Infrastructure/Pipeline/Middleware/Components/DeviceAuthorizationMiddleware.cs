using EcoGuardian_Backend.Resources.Domain.Repositories;

namespace EcoGuardian_Backend.IAM.Infrastructure.Pipeline.Middleware.Components;

public class DeviceAuthorizationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IDeviceRepository deviceRepository)
    {
        if (context.Request.Path.StartsWithSegments("/api/v1/metric"))
        {
            var deviceId = context.Request.Headers["Device-Id"].ToString();
            var apiKey = context.Request.Headers["Api-Key"].ToString();

            if (string.IsNullOrEmpty(deviceId) || string.IsNullOrEmpty(apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Device authentication required");
                return;
            }

            var valid = await deviceRepository.ValidateApiKeyAsync(deviceId, apiKey);
            if (!valid)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid device credentials");
                return;
            }
            context.Items["DeviceId"] = deviceId;
        }
        await next(context);
    }
}

