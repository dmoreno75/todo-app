
using FrozenLand.ToDo.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FrozenLand.ToDo.Tests.IntegrationTests.Fixtures
{
    internal class ToDoAppTestApi: WebApplicationFactory<Program>
    {
        public ToDoAppTestApi()
        {

        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<ITasksRepository, LocalTasksRepository>();
            });

            return base.CreateHost(builder);
        }
    }
}