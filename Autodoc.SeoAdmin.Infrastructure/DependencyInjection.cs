using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Application.Interfaces;
using Autodoc.SeoAdmin.Domain.Entities;
using Autodoc.SeoAdmin.Infrastructure.Persitance;
using Autodoc.SeoAdmin.Infrastructure.Repositories;
using Autodoc.SeoAdmin.Infrastructure.Services;
using Autodoc.SeoAdmin.Infrastructure.Services.UrlConstructors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autodoc.SeoAdmin.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IConnectionService, ConnectionServicePostgres>();
            services.AddScoped<ISeoRawDataRepository<RawSeoModelArticle>, SeoRawArticleUrlDataRepository>();
            services.AddScoped<ISeoRawDataRepository<RawSeoModel>, SeoRawCategoryUrlDataRepository>();
            services.AddScoped<IProccessStateService, ProccessStateService>();
            services.AddScoped<IGeneratedUrlWriter, GeneratedUrlWriter>();
            services.AddScoped<ISeoUrlProccessor<RawSeoModelArticle>, SeoArticleUrlProccessor>();
            services.AddScoped<IConstructorsSequenceBuilder<RawSeoModelArticle>, ArticleConstructorsSequenceBuilder>();
            services.AddScoped<IConstructorsSequenceBuilder<RawSeoModel>, CategoryConstructorsSequenceBuilder>();

            return services;
        }
    }
}
