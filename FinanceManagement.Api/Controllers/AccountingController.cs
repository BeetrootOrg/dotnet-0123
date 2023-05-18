using System.Threading;
using System.Threading.Tasks;

using AccountingManagement.Contracts.Http;
using AccountingManagement.Domain.Commands;

using FinanceManagement.Contracts.Http;
using FinanceManagement.Domain.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;


namespace FinanceManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> CreateAccounting([FromBody] CreateAccountingRequest request, CancellationToken cancellationToken = default)
        {

            var command = new CreateAccountingCommand
            {
                Title = request.Title,
                Value = request.Value
            };
            CreateAccountingResult result = await _mediator.Send(command, cancellationToken);

            return Created($"accounting/{result.Id}", new CreateAccountingResponse
            {
                Id = result.Id
            });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountingById(string id, CancellationToken cancellationToken = default)
        {
            GetAccountingByIdQuery query = new()
            {
                Id = id
            };

            GetAccountingByIdResult result = await _mediator.Send(query, cancellationToken);

            return result.Accounting == null
                ? NotFound(new ErrorModel
                {
                    Message = $"Accounting with id {id} not found"
                })
                : Ok(new GetAccountingByIdResponse
                {
                    Accounting = result.Accounting
                });
        }
    }
}