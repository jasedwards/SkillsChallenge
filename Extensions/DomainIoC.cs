using InterviewTest.ValidationFilters;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Extensions
{
    public static class DomainIoC
    {
        public static IServiceCollection RegisteredServices(this IServiceCollection  services)
        {
            return services;
        }

        public static IServiceCollection ConfigureValidationAttributes(this IServiceCollection services)
        {
            services.AddScoped<ValidationModelAttribute>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            return services;
        }
    }
}
