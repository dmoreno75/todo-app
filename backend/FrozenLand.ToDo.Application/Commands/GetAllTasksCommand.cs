using CSharpFunctionalExtensions;
using FrozenLand.ToDo.Application.Responses;
using MediatR;

namespace FrozenLand.ToDo.Application
{
    public class GetAllTasksCommand: IRequest<Result<TaskListResponse>>
    {
        public GetAllTasksCommand()
        {

        }
    }
}