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

		[Test]
		public async Task ToggleTaskStatus_ShouldUpdateStatusForTaskSucessfully()
		{
			const string taskId = "8ACE3216-C1C5-4D1F-A377-85183F9A2C26";
			var client = _api.CreateClient();

			var prevStatus = await GetStatusForTasks(client, taskId);

			var result = await client.PutAsync("tasks/toggle-task-status",
				JsonContent.Create(new ToggleTaskStatusRequest { TaskId = taskId })
			);

			Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

			var newStatus = await GetStatusForTasks(client, taskId);

			Assert.That(newStatus, Is.Not.EqualTo(prevStatus));
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

		private async Task<bool> GetStatusForTasks(HttpClient client, string taskId)
		{
			var allTasksActionResult = await client.GetAsync("tasks");
			Assert.True(allTasksActionResult.IsSuccessStatusCode);

			var tasks = await allTasksActionResult.Content.ReadFromJsonAsync<TaskListResponse>();

			if (tasks != null)
			{
				var task = tasks.Pending.SingleOrDefault(x => x.Id == taskId);
				if (task == null)
				{
					task = tasks.Completed.SingleOrDefault(x => x.Id == taskId);
				}

				if (task != null) return await Task.FromResult(task.Completed);
			}

			return false;
		}
	}
}