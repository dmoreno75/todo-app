using FrozenLand.ToDo.Application;
using FrozenLand.ToDo.Infrastructure;

namespace FrozenLand.ToDo.Tests.UnitTests.Handlers.Tasks
{
    public class GetAllTasksCommandHandlerTests
	{
        private GetAllTasksCommandHandler _queryAllCommand;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _queryAllCommand = new GetAllTasksCommandHandler(new DummyTasksRepository());
        }

        [Test]
        public async Task HandleQueryAll_SuccessfulResult()
        {
            // Arrange

            // Act
            var result = await _queryAllCommand.Handle(new GetAllTasksCommand());

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value.Pending.Length, Is.EqualTo(2));
            Assert.That(result.Value.Completed.Length, Is.EqualTo(2));
        }
    }
}