


using AutoMapper;

using BatteryMonitorApp.Contracts;
using BatteryMonitorApp.Contracts.Models.Http;
using BatteryMonitorApp.Domain.Repositories;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BatteryMonitorApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;


        public DataController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<IActionResult> PutData([FromBody] BatteryDataShortFormat request, CancellationToken cancellationToken = default)
        {
            var res = await BatteryMonitorAppContracts.AddData(_repository, _mapper, request);
            if (res) return Ok();
            return BadRequest();
        }
        //[HttpGet]
        //public async Task<IActionResult> GetData([FromQuery] GetBatteryDataRequest request, CancellationToken cancellationToken = default)
        //{
        //    //var get = new GetBatteryDataByDeviceAndDatesAndStatuses
        //    //{
        //    //    DeviceId = new Guid(request.DeviceId),
        //    //    End = (request.End == null ? DateTime.UtcNow : (DateTime)request.End),
        //    //    Start = (request.Srart == null ? DateTime.UtcNow.Date : (DateTime)request.Srart),
        //    //    Status = (request.Status == null ? new int[1] { 0 } : request.Status)
        //    //};

        //    //GetBatteryDataResult response = await _mediator.Send(get, cancellationToken);
        //    //return Ok(new GetBatteryDataResponse() { Datas = response.Datas });
        //}
    }
}
