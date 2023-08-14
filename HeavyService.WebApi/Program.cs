//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



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
using HeavyService.Service.Interfaces;
using HeavyService.Service.Interfaces.Auth;
using HeavyService.Service.Interfaces.Notifications;
using HeavyService.Service.Services.Auth;
using HeavyService.Service.Services.Common;
using HeavyService.Service.Services.Notifications;
using HeavyService.WebApi.Configurations;
using HeavyService.WebApi.Middlewares;
using RentHouse.WebApi.Configurations;
using RentHouse.WebApi.Configurations.Layer;

internal class Program
{
    private static void Main(string[] args)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // Add services to the container.
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddMemoryCache();
        builder.Services.AddScoped<IInstrumentComment, InstrumentCommentRepository>();
        builder.Services.AddScoped<IInstrumentRepository, InstrumentRepository>();
        builder.Services.AddScoped<ITransportCommentRepository, TransportCommentRepository>();
        builder.Services.AddScoped<ITransportRepository, TransportRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IEmailSMSSender, EmailSMSSender>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.ConfigureJwtAuth();
        builder.ConfigureDataAccess();
        builder.ConfigureServiceLayer();
        builder.ConfigureSwaggerAuth();
        var app = builder.Build();

        // Configure the HTTP request pipeline.



        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseStaticFiles();

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}