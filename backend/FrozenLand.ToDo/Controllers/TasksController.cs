using FrozenLand.ToDo.Models;
using FrozenLand.ToDo.Application;
using FrozenLand.ToDo.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FrozenLand.ToDo.Controllers
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
		public async Task<ActionResult<TaskListResponse>> Get()
		{
			var result = await _mediator.Send(new GetAllTasksCommand());

			if (result.IsSuccess) return result.Value;

			// Replace by an appropiate Http Code Status
			return new BadRequestObjectResult(result.Error);
		}

		[HttpPost]
		[Route("new-task")]
		public async Task<ActionResult<TaskItemResponse>> AddNewTask(TaskRequest task)
		{
			var result = await _mediator.Send(task.ToCommand());

			if (result.IsSuccess) return result.Value;

			// Replace by an appropiate Http Code Status
			return new BadRequestObjectResult(result.Error);
		}

		[HttpPut]
		[Route("toggle-task-status")]
		public async Task<ActionResult<TaskItemResponse>> ToggleTaskStatus(ToggleTaskStatusRequest request)
		{
			var result = await _mediator.Send(request.ToCommand());

			if (result.IsSuccess) return result.Value;

			// Replace by an appropiate Http Code Status
			return new BadRequestObjectResult(result.Error);
		}

		
	}
}