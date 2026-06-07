using Microsoft.Extensions.DependencyInjection;
using TarotSim.Core.Services;

namespace TarotSim.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddTarotSimCore(this IServiceCollection services)
    {
        services.AddScoped<IDeckService, DeckService>();
        services.AddScoped<ISpreadService, SpreadService>();
        services.AddHttpClient<InterpretationService>();
        services.AddScoped<IInterpretationService, InterpretationService>();

        return services;
    }
}
