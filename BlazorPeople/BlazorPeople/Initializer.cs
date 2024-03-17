using BlazorPeople.Application.Services;
using BlazorPeople.Domain.Entity;
using BlazorPeople.Domain.Interfaces.Repository;
using BlazorPeople.Domain.Interfaces.Services;
using BlazorPeople.Infrastructure.Repository;

namespace BlazorPeople
{
    public static class Initializer
    {
        public static void InitializeRepository(this IServiceCollection services)
        {
            services.AddScoped<IBaserepository<Person>, PersonRepository>();
        }

        public static void InitializeService(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
