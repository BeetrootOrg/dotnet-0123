using BatteryMonitorApp.Contracts.Http;
using BatteryMonitorApp.Domain.Commands;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BatteryMonitorApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DataController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<IActionResult> PutData([FromBody] BatteryDataRequest request, CancellationToken cancellationToken=default)
        {
            var command = new BatteryDataCommand
            {
                Current = request.Current,
                DateTime = request.DateTime,
                DeviceId = request.DeviceId,
                Status = request.Status,
                Voltage = request.Voltage,
                VoltageCharger = request.VoltageCharger,
            };

            BatteryDataResult result=await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
