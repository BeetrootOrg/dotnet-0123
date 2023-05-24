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
    [Produces("application/json")]
    public class AccountingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountingsController(IMediator mediator)
        {
            _mediator = mediator;
        }






        /// <summary>
        /// Create new accounting
        /// </summary>
        /// <param name="request">Accounting information</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Identifier of newly created accountings</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///    PUT /accountings
        ///    {
        ///        "title": "Accounting title",
        ///        "value": "Accounting value"
        ///    }   
        /// 
        /// </remarks> 
        /// <response code="201">Returns newly created accounting identifier</response>
        /// <response code="400">If request is invalid</response>
        /// <response code="500">If something went wrong</response>
        [HttpPut("")]
        [ProducesResponseType(typeof(CreateAccountingResponse), 201)]
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

        /// <summary>
        /// Get accounting by id
        /// </summary>
        /// <param name="id">Accounting identifier</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Accounting information</returns>
        /// <response code="200">Returns accounting information</response>
        /// <response code="404">If accounting with given id not found</response>
        /// <response code="500">If something went wrong</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetAccountingByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
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


        /// <summary>
        /// Update accounting value
        /// </summary>
        /// <param name="accountingId">Accounting identifier</param>
        /// <param name="request">Update information</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Nothing</returns>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///  PATCH /accountings/{accountingId}/value
        ///  {
        ///     "value": 100
        ///  }
        /// 
        /// </remarks>
        /// <response code="204">If accounting value updated successfully</response>
        /// <response code="400">If request is invalid</response>
        /// <response code="404">If accounting with given id not found</response>
        /// <response code="500">If something went wrong</response>
        [HttpPatch("{accountingId}/value")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
        public async Task<IActionResult> UpdateAccountingValue([FromRoute] string accountingId,
            [FromBody] UpdateAccountingValueRequest request,
            CancellationToken cancellationToken = default)
            {
                UpdateAccountingValueCommand command = new()
                {
                    AccountingId = accountingId,
                    Value = request.Value
                };

                await _mediator.Send(command, cancellationToken);
                return NoContent();
            }
    }
}