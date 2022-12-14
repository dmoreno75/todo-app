using FrozenLand.ToDo.Application;

namespace FrozenLand.ToDo.Models
{
	public class TaskRequest
	{
		public string? Description { get; set; }
	}

	public static class TaskRequestMappings
	{
		public static NewTaskCommand ToCommand(this TaskRequest task)
		{
			return new NewTaskCommand(task.Description);
		}
	}
}