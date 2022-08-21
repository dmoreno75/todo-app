using FrozenLand.ToDo.Application;
using MediatR;

namespace FronzenLand.ToDo.StartupExtensions
{
	public static class ApplicationServices
	{
		public static IServiceCollection AddCustomApplicationServices(this IServiceCollection services)
		{
			services.AddMediatR(typeof(Program).Assembly);
			services.AddMediatR(typeof(GetAllTasksCommand).Assembly);

			return services;
		}
	}
}