using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Contracts.Models;
using BatteryMonitorApp.UnitTests.Repositories;

using MediatR;

namespace BatteryMonitorApp.Domain.Queries
{
    public class GetBatteryDataByDeviceAndDatesAndStatuses : IRequest<GetBatteryDataResult>
    {
        public Guid DeviceId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int[] Status { get; set; }
    }

    public class GetBatteryDataResult
    {
        public IEnumerable<BatteryDataGet> Datas { get; set; }
    }

    internal class GetBatteryDataByDeviceAndDatesAndStatusesHandler : IRequestHandler<GetBatteryDataByDeviceAndDatesAndStatuses, GetBatteryDataResult>
    {
        private IRepository _repository;

        public GetBatteryDataByDeviceAndDatesAndStatusesHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBatteryDataResult> Handle(GetBatteryDataByDeviceAndDatesAndStatuses request, CancellationToken cancellationToken)
        {
            var dbresult = await _repository.GetBatteryData(request.DeviceId, request.Start, request.End, request.Status, cancellationToken);
            var arrresult = dbresult?.Select(x => new BatteryDataGet
            {
                Current = x.Current,
                DateTime = x.DateTime,
                Status = (BatteryEventStatus)x.Status,
                Voltage = x.Voltage,
                VoltageCharger = x.VoltageCharger
            }).ToArray();

            var response = new GetBatteryDataResult();
            response.Datas = arrresult != null ? arrresult : Array.Empty<BatteryDataGet>();

            return response;
        }
    }
}
