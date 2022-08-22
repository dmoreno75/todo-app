using CSharpFunctionalExtensions;
using FrozenLand.ToDo.Application.Responses;
using MediatR;

namespace FrozenLand.ToDo.Application
{
    public class ToggleTaskStatusCommand : IRequest<Result<TaskItemResponse>>
    {
        public string? TaskId { get; }
        public ToggleTaskStatusCommand(string? taskId)
        {
			TaskId = taskId;
        }
    }
}