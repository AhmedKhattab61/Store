using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;

namespace Services
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection AddApplicationSerivces(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IBasketService, BasketService>();

            return services;
        }
    }
}
