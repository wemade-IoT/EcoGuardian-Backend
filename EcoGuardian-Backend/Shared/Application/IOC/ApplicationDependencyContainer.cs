using EcoGuardian_Backend.CRM.Application.Internal.CommandServices;
using EcoGuardian_Backend.CRM.Application.Internal.EventHandlers;
using EcoGuardian_Backend.CRM.Application.Internal.OutboundServices;
using EcoGuardian_Backend.CRM.Application.Internal.QueryServices;
using EcoGuardian_Backend.CRM.Domain.Services;
using EcoGuardian_Backend.IAM.Application.Internal.CommandServices;
using EcoGuardian_Backend.IAM.Application.Internal.OutboundServices;
using EcoGuardian_Backend.IAM.Application.Internal.QueryServices;
using EcoGuardian_Backend.IAM.Domain.Services;
using EcoGuardian_Backend.IAM.Infrastructure.Hashing.BCrypt.Services;
using EcoGuardian_Backend.IAM.Infrastructure.Tokens.JWT.Services;
using EcoGuardian_Backend.IAM.Interfaces.ACL;
using EcoGuardian_Backend.IAM.Interfaces.ACL.Service;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.CommandServices;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.OutboundServices;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.QueryServices;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.CommandServices;
using EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.QueryServices;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;
using EcoGuardian_Backend.SubscriptionsAndPayment.Infrastructure.Persistence.EFC.Repositories;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.ACL;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.ACL.Service;
using EcoGuardian_Backend.Planning.Application.Internal.CommandServices;
using EcoGuardian_Backend.Planning.Application.Internal.QueryServices;
using EcoGuardian_Backend.Planning.Domain.Services;
using EcoGuardian_Backend.CRM.Application.Internal.OutboundServices;
using EcoGuardian_Backend.ProfilePreferences.Application.Internal.CommandServices;
using EcoGuardian_Backend.ProfilePreferences.Application.Internal.QueryServices;
using EcoGuardian_Backend.ProfilePreferences.Domain.Services;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.ACL;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.ACL.Service;

namespace EcoGuardian_Backend.Shared.Application.IOC;

public static class ApplicationDependencyContainer 
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        // Register application services here
        // Example: services.AddScoped<IExampleService, ExampleService>();

        // Register command handlers
        services.AddScoped<IPlantCommandService, PlantCommandService>();
        services.AddScoped<IPlantQueryService, PlantQueryService>();
        services.AddScoped<IWellnessStateCommandService, WellnessCommandService>();
        services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
        services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();
        services.AddScoped<IPaymentCommandService, PaymentCommandService>();
        services.AddScoped<IPaymentQueryService, PaymentQueryService>();
        services.AddScoped<ISubscriptionTypeCommandService, SubscriptionTypeCommandService>();
        services.AddScoped<ISubscriptionStateCommandService, SubscriptionStateCommandService>();
        services.AddScoped<IQuestionCommandService, QuestionCommandService>();
        services.AddScoped<IAnswerCommandService, AnswerCommandService>();
        services.AddScoped<IAnswerQueryService, AnswerQueryService>();
        services.AddScoped<IQuestionQueryService, QuestionQueryService>();

        // External User Service for CRM
        services.AddScoped<IExternalUserServiceCRM, ExternalUserServiceCRM>();




        // EventHandler
        services.AddScoped<IAddedQuestionEventHandler, AddedQuestionEventHandler>();

        services.AddScoped<IRoleCommandService, RoleCommandService>();
        services.AddScoped<IUserCommandService, UserCommandService>();
        services.AddScoped<IUserQueryService, UserQueryService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IHashingService, HashingService>();
        services.AddScoped<IIamContextFacade, IamContextFacade>();
        services.AddScoped<IProfileContextFacade, ProfileContextFacade>();
        services.AddScoped<IMonitorinContextFacade, MonitorinContextFacade>();
        services.AddScoped<IExternalUserService, ExternalUserService>();
        services.AddScoped<IOrderCommandService, OrderCommandService>();
        services.AddScoped<IOrderStateCommandService, OrderStateCommandService>();
        services.AddScoped<IOrderQueryService, OrderQueryService>();
        
        services.AddScoped<IProfileCommandService, ProfileCommandService>();
        services.AddScoped<IProfileQueryService, ProfileQueryService>();
        
        // Register other application services as needed
        /*services.AddScoped<IExternalCustomerService, ExternalCustomerService>();*/

        return services;
    }
}
