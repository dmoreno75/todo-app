using CSharpFunctionalExtensions;
using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Infrastructure
{
	public interface ITasksRepository: IBaseRepository<CoreModels.Task>
	{
		Task<Result<CoreModels.Task>> ToggleStatus(string TaskId);
	}
}