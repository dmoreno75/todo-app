using FrozenLand.ToDo.Tests.IntegrationTests.Fixtures;
using System.Net;

namespace FrozenLand.ToDo.Tests
{
    public class IntegrationTasksTests
    {
        private readonly ToDoAppTestApi _api;
        public IntegrationTasksTests()
        {
            _api = new ToDoAppTestApi();
        }

        [Test]
        public async Task ShouldGetAll()
        {
            var client = _api.CreateClient();
            var result = await client.GetAsync("tasks");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}