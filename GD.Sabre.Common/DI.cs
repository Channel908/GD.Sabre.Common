using GD.Sabre.Common.Core;
using GD.Sabre.Common.Core.Factories;
using GD.Sabre.Common.Core.Models.Options;
using GD.Sabre.Common.Service.Session;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GD.Sabre.Common
{
    public static class DI
    {

        public static IServiceCollection AddSabreCommon(this IServiceCollection services, IConfigurationSection section)
        {
            services.AddOptions<SabreServicesOptions>().Bind(section);
            services.AddTransient<ISoapEnvelopeService, SoapEnvelopeService>();
            services.AddTransient<ISoapServiceFactory, SoapServiceFactory>();
            services.AddTransient<ISabreSessionPool, SabreSessionPool>();
            services.AddTransient<IRequestHeaderBuilderFactory, RequestHeaderBuilderFactory>();


            return services;
        }

    }
}
