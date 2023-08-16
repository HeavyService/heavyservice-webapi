using HeavyService.Service.Interfaces.Auth;
using HeavyService.Service.Services.Auth;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Services.Common;
using HeavyService.Service.Interfaces.InstrumentComments;
using HeavyService.Service.Services.InstrumentComments;
using HeavyService.Service.Services.TransportComments;
using HeavyService.Service.Interfaces.TransportComments;
using HeavyService.Service.Interfaces.Instruments;
using HeavyService.Service.Services.Instruments;
using HeavyService.Service.Services.Transports;
using HeavyService.Service.Interfaces.Transports;
using HeavyService.Service.Services.Notifications;
using HeavyService.Service.Interfaces.Notifications;
using HeavyService.Service.Interfaces.Users;
using HeavyService.Service.Services.Users;

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
        builder.Services.AddScoped<IInstrumentService, InstrumentService>();
        builder.Services.AddScoped<IInstrumentCommentService, InstrumentCommentService>();
        builder.Services.AddScoped<ITransportService, TransportService>();
        builder.Services.AddScoped<ITransportCommentService, TransportCommentService>();
        builder.Services.AddScoped<IUserservice, UserService>();
    }
}