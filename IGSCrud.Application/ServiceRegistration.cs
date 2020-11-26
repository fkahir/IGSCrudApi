using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IGSCrud.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
