using Microsoft.Extensions.DependencyInjection;
using WhoKnowsApp.APIClient.Endpoints;
using WhoKnowsApp.APIClient.Endpoints.Interfaces;

namespace WhoKnowsApp.APIClient
{
    public static class ApiClientServiceExtensions
    {
        public static IServiceCollection AddApiClientServiceExtensions(this IServiceCollection services)
        {
            services.AddTransient<IQuestionEndpoints, QuestionEndpoints>();
            return services;
        }
    }
}