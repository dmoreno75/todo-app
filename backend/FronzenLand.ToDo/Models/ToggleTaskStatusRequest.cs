using FrozenLand.ToDo.Application;

namespace FronzenLand.ToDo.Models
{
	public class ToggleTaskStatusRequest
	{
		public string? TaskId { get; set; }
	}

	public static class ToggleTaskStatusRequestMappings
	{
		public static ToggleTaskStatusCommand ToCommand(this ToggleTaskStatusRequest task)
		{
			return new ToggleTaskStatusCommand(task.TaskId);
		}
	}
}