using CSharpFunctionalExtensions;
using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Infrastructure
{
	public class DummyTasksRepository : ITasksRepository
	{
		IList<CoreModels.Task> _tasks = new List<CoreModels.Task>();

		public DummyTasksRepository()
		{
			_tasks.Add(new CoreModels.Task(Guid.NewGuid().ToString(), DateTime.Now, false, "me", "Lorem ipsum"));
			_tasks.Add(new CoreModels.Task(Guid.NewGuid().ToString(), DateTime.Now, true, "me", "Lorem ipsum"));
			_tasks.Add(new CoreModels.Task(Guid.NewGuid().ToString(), DateTime.Now, true, "me", "Lorem ipsum"));
			_tasks.Add(new CoreModels.Task(Guid.NewGuid().ToString(), DateTime.Now, false, "me", "Lorem ipsum"));
		}

		public async Task<Result<IList<CoreModels.Task>>> GetAll()
		{
			var result = Result.Success(_tasks);
			return await Task.FromResult(result);
		}
	}
}