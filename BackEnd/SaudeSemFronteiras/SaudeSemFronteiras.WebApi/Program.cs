using Serilog;
using Serilog.Exceptions;

namespace SaudeSemFronteiras.WebApi;
public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Warning(ex, "An error occurred starting the application");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Console())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}