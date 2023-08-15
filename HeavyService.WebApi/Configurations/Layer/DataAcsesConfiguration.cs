using HeavyService.DataAccess.Interfaces.InstrumentComments;
using HeavyService.DataAccess.Interfaces.Instruments;
using HeavyService.DataAccess.Interfaces.Roles;
using HeavyService.DataAccess.Interfaces.TransportComments;
using HeavyService.DataAccess.Interfaces.Transports;
using HeavyService.DataAccess.Interfaces.UserRoles;
using HeavyService.DataAccess.Interfaces.Users;
using HeavyService.DataAccess.Repositories.InstrumentComment;
using HeavyService.DataAccess.Repositories.Instruments;
using HeavyService.DataAccess.Repositories.Roles;
using HeavyService.DataAccess.Repositories.TransportComments;
using HeavyService.DataAccess.Repositories.Transports;
using HeavyService.DataAccess.Repositories.UserRoles;
using HeavyService.DataAccess.Repositories.Users;

namespace HeavyService.WebApi.Configurations.Layer;

public static class DataAcsesConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IInstrumentComment, InstrumentCommentRepository>();
        builder.Services.AddScoped<IInstrumentRepository, InstrumentRepository>();
        builder.Services.AddScoped<ITransportCommentRepository, TransportCommentRepository>();
        builder.Services.AddScoped<ITransportRepository, TransportRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    }
}
