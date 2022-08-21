using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Infrastructure
{
	public interface ITasksRepository: IBaseRepository<CoreModels.Task>
	{
	}
}