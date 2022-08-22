using CSharpFunctionalExtensions;
using FrozenLand.ToDo.Application.Responses;
using FrozenLand.ToDo.Infrastructure;
using MediatR;

using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Application
{
	public class GetAllTasksCommandHandler : IRequestHandler<GetAllTasksCommand, Result<TaskListResponse>>
	{
		private readonly ITasksRepository _tasks;
		private readonly Func<IList<CoreModels.Task>, TaskListResponse>
			_mapList = model => new TaskListResponse(
					model.Where(x => !x.Completed).Select(y => y.ToResponse()).ToArray(),
					model.Where(x => x.Completed).Select(y => y.ToResponse()).ToArray()
			);

		public GetAllTasksCommandHandler(ITasksRepository tasks)
		{
			_tasks = tasks;
		}

		public async Task<Result<TaskListResponse>> Handle(GetAllTasksCommand request, CancellationToken cancellationToken = default)
		{
			var result = await _tasks.GetAll();

			if (result.IsSuccess) return Result.Success(_mapList(result.Value));

			throw new Exception("TODO Deal with this scenario");
		}
	}
}