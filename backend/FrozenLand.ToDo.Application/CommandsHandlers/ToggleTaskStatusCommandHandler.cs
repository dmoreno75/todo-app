using CSharpFunctionalExtensions;
using FrozenLand.ToDo.Application.Responses;
using FrozenLand.ToDo.Infrastructure;
using MediatR;

using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Application
{
	public class ToggleTaskStatusCommandHandler : IRequestHandler<ToggleTaskStatusCommand, Result<TaskItemResponse>>
	{
		private readonly ITasksRepository _tasks;
		private readonly Func<CoreModels.Task, TaskItemResponse> _map = model => model.ToResponse();

		public ToggleTaskStatusCommandHandler(ITasksRepository tasks)
		{
			_tasks = tasks;
		}

		public async Task<Result<TaskItemResponse>> Handle(ToggleTaskStatusCommand command, CancellationToken cancellationToken = default)
		{
			// Add a proper validation for the command rather than an if
			if (command.TaskId != null)
			{
				var result = await _tasks.ToggleStatus(command.TaskId);
				if (result.IsSuccess) return Result.Success(_map(result.Value));
			}

			return Result.Failure<TaskItemResponse>("TaskId can't be empty!");
		}
	}
}