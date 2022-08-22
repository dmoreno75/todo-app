using CSharpFunctionalExtensions;
using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Infrastructure
{
	public class LocalTasksRepository : ITasksRepository
	{
		IList<CoreModels.Task> _tasks = new List<CoreModels.Task>();

		public LocalTasksRepository()
		{
		}

		public async Task<Result<IList<CoreModels.Task>>> GetAll()
		{
			return await Task.FromResult(Result.Success(_tasks));
		}

		public async Task<Result<CoreModels.Task>> Save(string description)
		{
			var task = new CoreModels.Task(
				Guid.NewGuid().ToString(),
				DateTime.Now,
				false,
				description);

			_tasks.Add(task);

			return await Task.FromResult(Result.Success(task));
		}

		public Task<Result<CoreModels.Task>> ToggleStatus(string taskId)
		{
			var task = _tasks.Where(x => x.Id == taskId).SingleOrDefault();
			if (task != null)
			{
				_tasks.Remove(task);
				var newTask = task with { 
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