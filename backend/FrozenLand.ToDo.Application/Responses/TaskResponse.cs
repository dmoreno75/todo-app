using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Application.Responses
{
    public sealed record TaskResponse(string Id, DateTime CreationDate, bool Completed, string CreatedBy, string Description, DateTime CompletedDate);
	
	public static class TaskResponseMapping
	{
		public static TaskResponse ToResponse(this CoreModels.Task task)
		{
			return new TaskResponse(
				task.Id,
				task.CreationDate,
				task.Completed,
				task.CreatedBy,
				task.Description,
				task.CompleteDate);
		}
	}
}