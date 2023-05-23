using InterviewTest.Models;
using InterviewTest.Repositories;
using InterviewTest.Repositories.Abstractions;
using InterviewTest.Repositories.Wrappers;

namespace InterviewTest.Extensions
{
    public static class RepositoryIoC
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPersonRepository), typeof(PersonRepository));
            services.AddTransient(typeof(IPersonRepositoryWrapper), typeof(PersonRepositoryWrapper));

            return services;
        }
    }
}
