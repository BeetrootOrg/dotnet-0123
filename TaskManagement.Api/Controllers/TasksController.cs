using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using TaskManagement.Contracts.Http;
using TaskManagement.Domain.Commands;

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
    }
}