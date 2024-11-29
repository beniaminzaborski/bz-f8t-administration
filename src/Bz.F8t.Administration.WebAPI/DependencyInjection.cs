using Bz.F8t.Administration.WebAPI.ExceptionsHandling;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using Npgsql;
using Azure.Monitor.OpenTelemetry.Exporter;

namespace Bz.F8t.Administration.WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomControllers(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(GlobalExceptionFilter));
            options.SuppressAsyncSuffixInActionNames = false;
        });

        return services;
    }

    public static IServiceCollection AddObservability(this IServiceCollection services, IConfiguration config, string serviceName, string serviceVersion)
    {
        return services
            .AddOpenTelemetry()
            .WithTracing(builder => builder
                .AddSource(serviceName)
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName, serviceVersion: serviceVersion))
                .AddAspNetCoreInstrumentation()
                .AddNpgsql()
                .AddMassTransitInstrumentation().AddSource("MassTransit")
                //.AddConsoleExporter()
                .AddTraceExporter(config))
            .WithMetrics(builder => builder
                .AddMeter(serviceName)
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName, serviceVersion: serviceVersion))
                .AddRuntimeInstrumentation()
                .AddAspNetCoreInstrumentation()
                //.AddConsoleExporter()
                .AddMetricsExporter(config))
            .Services;
    }

    private static TracerProviderBuilder AddTraceExporter(this TracerProviderBuilder tracerProviderBuilder, IConfiguration config)
    {
        var useJaeger = config.GetValue<bool>("Jaeger:UseJaeger");
        if(useJaeger)
        {
            var jaegerEndpoint = config.GetValue<string>("Jaeger:Endpoint");
            return tracerProviderBuilder.AddOtlpExporter(o =>
            {
                o.Endpoint = new Uri(jaegerEndpoint);
            });
        }
        else
        {
            var appInsightsConnectionString = GetApplicationInsightsConnectionString(config);
            return tracerProviderBuilder.AddAzureMonitorTraceExporter(cfg => cfg.ConnectionString = appInsightsConnectionString);
        }
    }

    private static MeterProviderBuilder AddMetricsExporter(this MeterProviderBuilder meterProviderBuilder, IConfiguration config)
    {
        var appInsightsConnectionString = GetApplicationInsightsConnectionString(config);

        // TODO: Use Prometheus exporter here!
        return meterProviderBuilder.AddAzureMonitorMetricExporter(cfg => cfg.ConnectionString = appInsightsConnectionString);
    }

    private static string? GetApplicationInsightsConnectionString(IConfiguration config) => config.GetConnectionString("ApplicationInsights");
}
