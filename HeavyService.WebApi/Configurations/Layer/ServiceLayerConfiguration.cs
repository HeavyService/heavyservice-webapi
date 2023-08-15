using HeavyService.Service.Interfaces;
using HeavyService.Service.Interfaces.Auth;
using HeavyService.Service.Interfaces.Notifications;
using HeavyService.Service.Services.Auth;
using HeavyService.Service.Services.Common;
using HeavyService.Service.Services.Notifications;

namespace HeavyService.WebApi.Configurations.Layer;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IEmailSMSSender, EmailSMSSender>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
    }
}