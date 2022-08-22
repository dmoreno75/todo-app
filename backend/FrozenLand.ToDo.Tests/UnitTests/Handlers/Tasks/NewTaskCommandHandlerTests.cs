using FrozenLand.ToDo.Application;
using FrozenLand.ToDo.Infrastructure;
using NUnit.Framework.Constraints;

namespace FrozenLand.ToDo.Tests.UnitTests.Handlers.Tasks
{
	public class NewTaskCommandHandlerTests
	{
		private NewTaskCommandHandler _commandHandler;
		private ITasksRepository _tasksRepository = new DummyTasksRepository();

		[SetUp]
		public void Setup()
		{
			// Arrange
			_commandHandler = new NewTaskCommandHandler(_tasksRepository);
		}

		[Test]
		public async Task HandleNewTask_SuccessfulResult()
		{
			const string description = "sample-task";
			// Arrange

			// Act
			var result = await _commandHandler.Handle(new NewTaskCommand(description));

			var tasks = await _tasksRepository.GetAll();
			var pending = tasks.Value.Count(x => !x.Completed);

			// Assert
			Assert.IsTrue(result.IsSuccess);
			Assert.That(result.Value.Description, Is.EqualTo(description));
			Assert.That(pending, Is.EqualTo(3));
		}
	}
}