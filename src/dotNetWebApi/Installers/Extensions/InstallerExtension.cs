using dotNetWebApi.Installers.Interfaces;

namespace dotNetWebApi.Installers.Extensions;

public static class InstallerExtension
{
    public static void Install(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var services = typeof(Program).Assembly.ExportedTypes
            .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
        
        services.ForEach(x => x.InstallServices(serviceCollection, configuration));
    }
}