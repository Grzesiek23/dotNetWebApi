namespace dotNetWebApi.Installers.Interfaces;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}