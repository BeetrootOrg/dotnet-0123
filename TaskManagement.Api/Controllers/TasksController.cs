using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using TaskManagement.Contracts.Http;
using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Queries;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request,
            CancellationToken cancellationToken = default)
        {
            CreateTaskCommand command = new()
            {
                Title = request.Title,
                Description = request.Description
            };

            CreateTaskResult result = await _mediator.Send(command, cancellationToken);

            return Created($"tasks/{result.Id}", new CreateTaskResponse
            {
                Id = result.Id
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(string id, CancellationToken cancellationToken = default)
        {
            GetTaskByIdQuery query = new()
            {
                Id = id
            };

            GetTaskByIdResult result = await _mediator.Send(query, cancellationToken);

            return result.Task == null
                ? NotFound(new ErrorModel
                {
                    Message = $"Task with id {id} not found"
                })
                : Ok(new GetTaskByIdResponse
                {
                    Task = result.Task
                });
        }

    }
}