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
			var result = Result.Success(_tasks);
			return await Task.FromResult(result);
		}
	}
}