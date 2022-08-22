using CSharpFunctionalExtensions.Json.Serialization;
using FronzenLand.ToDo.Models;
using FrozenLand.ToDo.Application.Responses;
using FrozenLand.ToDo.Tests.IntegrationTests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

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

		[Test]
		public async Task NewTask_ShouldBeAddedToRepository()
		{
			var client = _api.CreateClient();

			var prevNumber = await GetPendingTasks(client);

			var result = await client.PostAsync("tasks/new-task",
				JsonContent.Create(new TaskRequest { Description = "sample-task" })
			);

			Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

			var newNumber = await GetPendingTasks(client);
			
			Assert.That(newNumber, Is.GreaterThan(prevNumber));
		}

		private async Task<int> GetPendingTasks(HttpClient client)
		{
			var allTasksActionResult = await client.GetAsync("tasks");
			Assert.True(allTasksActionResult.IsSuccessStatusCode);

			var tasks = await allTasksActionResult.Content.ReadFromJsonAsync<TaskListResponse>();
			
			if (tasks != null)
				return await Task.FromResult(tasks.Pending.Length);

			return 0;
		}
	}
}