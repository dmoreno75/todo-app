using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FrozenLand.ToDo.Infrastructure
{
    public static class SetupInfrastructure
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
		{
			services.AddSingleton<ITasksRepository, LocalTasksRepository>();
			return services;
		}
	}
}