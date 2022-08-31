using dotNetWebApi.Application.Contracts;
using dotNetWebApi.Installers.Interfaces;
using dotNetWebApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace dotNetWebApi.Installers;

public class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Connection string 'ConnectionString' not found.");
        services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IWebApiDbContext, WebApiDbContext>();
    }
}