using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tanner.Telemetry.AppInsights
{
    public static class ApplicationInsightsInitialize
    {
        public static void AddTannerTelemetry(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            ApplicationInsights option = configuration.GetSection(nameof(ApplicationInsights)).Get<ApplicationInsights>();
            serviceCollection.AddSingleton(option);
            serviceCollection.AddApplicationInsightsTelemetry(option.InstrumentationKey);
            serviceCollection.AddSingleton(typeof(ITraceHelper), typeof(TraceHelper));
        }
    }
}
