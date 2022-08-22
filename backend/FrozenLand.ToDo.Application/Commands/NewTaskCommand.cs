using CSharpFunctionalExtensions;
using FrozenLand.ToDo.Application.Responses;
using MediatR;

namespace FrozenLand.ToDo.Application
{
    public class NewTaskCommand : IRequest<Result<TaskItemResponse>>
    {
        public string? Description { get; }
        public NewTaskCommand(string? description)
        {
            Description = description;
        }
    }
}