using CSharpFunctionalExtensions;
using FrozenLand.ToDo.Application.Responses;
using FrozenLand.ToDo.Infrastructure;
using MediatR;

using CoreModels = FrozenLand.ToDo.Core.Models;

namespace FrozenLand.ToDo.Application
{
	public class GetAllTasksCommandHandler : IRequestHandler<GetAllTasksCommand, Result<IList<TaskResponse>>>
	{
		private readonly ITasksRepository _tasks;
		private readonly Func<IList<CoreModels.Task>, IList<TaskResponse>>
			_mapList = model => model
				.Select(x => x.ToResponse())
				.ToList();

		public GetAllTasksCommandHandler(ITasksRepository tasks)
		{
			_tasks = tasks;
		}

		public async Task<Result<IList<TaskResponse>>> Handle(GetAllTasksCommand request, CancellationToken cancellationToken)
		{
			var result = await _tasks.GetAll();

			if (result.IsSuccess) return Result.Success(_mapList(result.Value));

			throw new Exception("");
		}
	}
}