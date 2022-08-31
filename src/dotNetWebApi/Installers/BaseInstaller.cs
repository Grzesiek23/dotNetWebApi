using System.Reflection;
using dotNetWebApi.Application.Contracts;
using MediatR;
using dotNetWebApi.Installers.Interfaces;

namespace dotNetWebApi.Installers;

public class BaseInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(x => x.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" }));
        
        services.AddMediatR(typeof(IWebApiDbContext).GetTypeInfo().Assembly);
    }
}