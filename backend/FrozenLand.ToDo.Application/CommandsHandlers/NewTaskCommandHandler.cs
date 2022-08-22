using CSharpFunctionalExtensions;
using FrozenLand.ToDo.Application.Responses;
using FrozenLand.ToDo.Infrastructure;
using MediatR;

using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Application
{
	public class NewTaskCommandHandler : IRequestHandler<NewTaskCommand, Result<TaskItemResponse>>
	{
		private readonly ITasksRepository _tasks;
		private readonly Func<CoreModels.Task, TaskItemResponse> _map = model => model.ToResponse();

		public NewTaskCommandHandler(ITasksRepository tasks)
		{
			_tasks = tasks;
		}

		public async Task<Result<TaskItemResponse>> Handle(NewTaskCommand command, CancellationToken cancellationToken = default)
		{
			if (command.Description !=null)
			{
				var result = await _tasks.Save(command.Description);
				if (result.IsSuccess) return Result.Success(_map(result.Value));
			}

			return Result.Failure<TaskItemResponse>("Description can't be empty!");
		}
	}
}