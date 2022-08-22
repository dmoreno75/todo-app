using FrozenLand.ToDo.Application;
using FrozenLand.ToDo.Infrastructure;
using NUnit.Framework.Constraints;

namespace FrozenLand.ToDo.Tests.UnitTests.Handlers.Tasks
{
	public class ToggleTaskStatusCommandHandlerTests
	{
		private ToggleTaskStatusCommandHandler _commandHandler;
		private ITasksRepository _tasksRepository = new DummyTasksRepository();

		[SetUp]
		public void Setup()
		{
			// Arrange
			_commandHandler = new ToggleTaskStatusCommandHandler(_tasksRepository);
		}

		[Test]
		public async Task HandleNewTask_SuccessfulResult()
		{
			const string taskId = "8ACE3216-C1C5-4D1F-A377-85183F9A2C26";
			// Arrange

			var prevStatus = await CurrentStatusForTask(taskId);

			// Act
			var result = await _commandHandler.Handle(new ToggleTaskStatusCommand(taskId));

			// Assert

			var currentStatus = await CurrentStatusForTask(taskId);
			Assert.IsTrue(result.IsSuccess);
			Assert.That(result.Value.Completed, Is.EqualTo(!prevStatus));
			Assert.That(currentStatus, Is.Not.EqualTo(prevStatus));
		}

		private async Task<bool> CurrentStatusForTask(string taskId)
		{
			var tasks = await _tasksRepository.GetAll();
			var selectedTask = tasks.Value.Where(x => x.Id == taskId).Single();
			return selectedTask.Completed;
		}
	}
}