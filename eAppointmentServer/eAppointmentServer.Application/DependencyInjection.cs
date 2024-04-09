using Microsoft.Extensions.DependencyInjection;

namespace eAppointmentServer.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
