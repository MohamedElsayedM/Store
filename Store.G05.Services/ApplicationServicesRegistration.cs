using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.G05.Services.Abstractions;
using Store.G05.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Services
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) 
        {
           services.AddAutoMapper(M => M.AddProfile(new ProductProfile(configuration)));
           services.AddScoped<IServiceManger, ServiceManger>();

            return services;
        }
    }
}
