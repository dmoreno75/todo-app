using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Application.Responses
{
	public sealed record TaskListResponse(TaskItemResponse[] Pending, TaskItemResponse[] Completed);

	public sealed record TaskItemResponse(string Id, DateTime CreationDate, bool Completed, string CreatedBy, string Description, DateTime CompletedDate);
	
	public static class TaskResponseMapping
	{
		public static TaskItemResponse ToResponse(this CoreModels.Task task)
		{
			return new TaskItemResponse(
				task.Id,
				task.CreationDate,
				task.Completed,
				task.CreatedBy,
				task.Description,
				task.CompleteDate);
		}
	}
}