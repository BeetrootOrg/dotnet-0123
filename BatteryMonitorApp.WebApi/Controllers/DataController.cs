using AutoMapper;

using BatteryMonitorApp.Contracts.Models.Http;
using BatteryMonitorApp.Domain.Models.DataBase;
using BatteryMonitorApp.Domain.Repositories;

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
        public async Task<IActionResult> PutData([FromBody] BatteryDataShortFormat request, CancellationToken token = default)
        {
            if (request == null) return StatusCode(StatusCodes.Status415UnsupportedMediaType);
            try
            {
                var battdata = _mapper.Map<BatteryData>(request);
                return (await _repository.AddData(battdata, token)) > 0 ?
                    Ok() :
                    BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetData([FromQuery] BatteryDataRequest request, CancellationToken cancellationToken = default)
        {
            var result = Array.Empty<BatteryDataView>();
            if (request == null || request.Di==Guid.Empty) return StatusCode(StatusCodes.Status415UnsupportedMediaType);
            try
            {
                result = (await _repository.GetBatteryData(request.Di, request.F, request.T, request.S))
                   .Select(x => BatteryDataView.FromBatteryData(x)).ToArray();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(result);
        }
    }
}
