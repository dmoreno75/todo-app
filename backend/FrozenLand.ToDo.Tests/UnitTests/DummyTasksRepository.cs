using CSharpFunctionalExtensions;
using System.ComponentModel;
using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Infrastructure
{
	public class DummyTasksRepository : ITasksRepository
	{
		IList<CoreModels.Task> _tasks = new List<CoreModels.Task>();

		public DummyTasksRepository()
		{
			_tasks.Add(new CoreModels.Task("8ACE3216-C1C5-4D1F-A377-85183F9A2C26", DateTime.Now, false, "Lorem ipsum"));
			_tasks.Add(new CoreModels.Task(Guid.NewGuid().ToString(), DateTime.Now, true, "Lorem ipsum"));
			_tasks.Add(new CoreModels.Task(Guid.NewGuid().ToString(), DateTime.Now, true, "Lorem ipsum"));
			_tasks.Add(new CoreModels.Task(Guid.NewGuid().ToString(), DateTime.Now, false, "Lorem ipsum"));
		}

		public async Task<Result<IList<CoreModels.Task>>> GetAll()
		{
			var result = Result.Success(_tasks);
			return await Task.FromResult(result);
		}

		public Task<Result<CoreModels.Task>> Save(string description)
		{
			var task = new CoreModels.Task(
				Guid.NewGuid().ToString(),
				DateTime.Now,
				false,
				description);

			_tasks.Add(task);

			return Task.FromResult(Result.Success(task));
		}

		public Task<Result<CoreModels.Task>> ToggleStatus(string taskId)
		{
			var task = _tasks.Where(x => x.Id == taskId).SingleOrDefault();
			if (task != null)
			{
				_tasks.Remove(task);
				var newTask = task with
				{
					Id = task.Id,
					Completed = !task.Completed
				};
				_tasks.Add(newTask);

				return Task.FromResult(Result.Success(newTask));
			}

			return Task.FromResult(Result.Failure<CoreModels.Task>("Task not found"));
		}
	}
}