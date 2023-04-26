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
    [Produces("application/json")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create new task
        /// </summary>
        /// <param name="request">Task information</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Identifier of newly created taks</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///    PUT /tasks
        ///    {
        ///        "title": "Task title",
        ///        "description": "Task description"
        ///    }   
        /// 
        /// </remarks> 
        /// <response code="201">Returns newly created task identifier</response>
        /// <response code="400">If request is invalid</response>
        /// <response code="500">If something went wrong</response>
        [HttpPut]
        [ProducesResponseType(typeof(CreateTaskResponse), 201)]
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

        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="id">Task identifier</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task information</returns>
        /// <response code="200">Returns task information</response>
        /// <response code="404">If task with given id not found</response>
        /// <response code="500">If something went wrong</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetTaskByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
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