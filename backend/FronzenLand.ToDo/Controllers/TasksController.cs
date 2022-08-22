using FrozenLand.ToDo.Application;
using FrozenLand.ToDo.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FronzenLand.ToDo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TasksController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger<TasksController> _logger;

		public TasksController(IMediator mediator, ILogger<TasksController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet]
		public async Task<TaskListResponse> Get()
		{
			var result = await _mediator.Send(new GetAllTasksCommand());

			if (result.IsSuccess) return result.Value;

			throw new Exception("Can't get any tasks");
		}
	}
}