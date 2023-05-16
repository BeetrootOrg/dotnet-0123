using System.Threading;
using System.Threading.Tasks;

using AccountingManagement.Contracts.Http;
using AccountingManagement.Domain.Commands;

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

            return Created($"tasks/{result.Id}", new CreateAccountingResponse
            {
                Id = result.Id
            });

        }
    }
}