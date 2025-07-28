using Contracts;
using Entities.Configuration;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Service;
using Service.Contracts;
using System.Reflection;

namespace RoadRunner.Extensions;
public static class ServiceExtensions
{
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void SetupConfiguration(this MauiAppBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using Stream? stream = assembly.GetManifestResourceStream("RoadRunner.appsettings.json")
            ?? throw new FileNotFoundException("appsettings.json not found in the assembly manifest resources.");
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        builder.Configuration.AddConfiguration(config);
    }

    public static void ConfigurePlcSettings(this MauiAppBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(@"C:\Applications\RoadRunner\plcsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Add the configuration to the builder's configuration
        builder.Configuration.AddConfiguration(configuration);

        // Register the PLCConfiguration for dependency injection
        builder.Services.Configure<PLCConfiguration>(
            configuration.GetSection("PLCConfiguration"));        
    }

    public static void ConfigurePlantSettings(this MauiAppBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(@"C:\Applications\RoadRunner\plantsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Add the configuration to the builder's configuration
        builder.Configuration.AddConfiguration(configuration);

        // Register the PlantConfiguration for dependency injection
        builder.Services.Configure<PlantConfiguration>(
            configuration.GetSection("PlantConfiguration"));
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("RoadRunner")));
}
