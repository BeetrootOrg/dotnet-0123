using AutoMapper;

using BatteryMonitorApp.Contracts.Models.Http;
using BatteryMonitorApp.Domain.Models.DataBase;
using BatteryMonitorApp.Domain.Repositories;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BatteryMonitorApp.WebApp.Areas.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [AllowAnonymous]
    public class DataController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;


        public DataController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        /// <summary>
        /// simple format for sending data
        /// </summary>
        /// <param name="request">BatteryDataShortFormat data for send</param>
        /// <param name="token">CancellationToken</param>
        /// <returns></returns>
        /// <response code="200">Data sending</response>
        /// <response code="415">UnsupportedMediaType</response>
        /// <response code="500">InternalServerError</response>
        [HttpPut]
        [ProducesResponseType(200)]
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
        /// <summary>
        /// simple format for get data
        /// </summary>
        /// <param name="request">BatteryDataRequest</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Array of Battery Data</returns>
        /// <remarks>
        /// Sample Query:
        ///     /api/Data?Di=DE88CE88-E888-8A88-8888-888888888888
        /// </remarks>
        /// <response code="200">Data sending</response>
        /// <response code="415">UnsupportedMediaType</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet]
        [ProducesResponseType(typeof(BatteryDataView[]),200)]
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
