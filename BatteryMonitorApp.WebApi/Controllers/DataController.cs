using BatteryMonitorApp.Contracts.Http;
using BatteryMonitorApp.Contracts.Models;
using BatteryMonitorApp.Domain.Commands;
using BatteryMonitorApp.Domain.Queries;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> PutData([FromBody] BatteryDataRequest request, CancellationToken cancellationToken = default)
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

            BatteryDataResult result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetData([FromQuery] GetBatteryDataRequest request, CancellationToken cancellationToken = default)
        {
            var get = new GetBatteryDataByDeviceAndDatesAndStatuses
            {
                DeviceId = new Guid(request.DeviceId),
                End = (request.End == null ? DateTime.UtcNow : (DateTime)request.End),
                Start = (request.Srart == null ? DateTime.UtcNow.Date : (DateTime)request.Srart),
                Status = (request.Status == null ? new int[1] { 0 } : request.Status)
            };

            GetBatteryDataResult response = await _mediator.Send(get, cancellationToken);
            return Ok(new GetBatteryDataResponse() { Datas = response.Datas });
        }
    }
}
