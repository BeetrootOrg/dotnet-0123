using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Contracts.Http;
using BatteryMonitorApp.Contracts.Models;
using BatteryMonitorApp.Domain.DbContexts;
using BatteryMonitorApp.Domain.Models.DataBase;
using BatteryMonitorApp.UnitTests.Repositories;

using MediatR;

namespace BatteryMonitorApp.Domain.Commands
{
    public class BatteryDataCommand : IRequest<BatteryDataResult>
    {
        public Guid DeviceId { get; init; }
        public float Voltage { get; init; } = 0;
        public float Current { get; init; } = 0;
        public float VoltageCharger { get; init; } = 0;
        public DateTime DateTime { get; init; } = DateTime.Now;
        public BatteryEventStatus Status { get; init; } = BatteryEventStatus.Default;
    }

    public class BatteryDataResult
    {
        public bool Result { get; init; }
    }

    internal class BatteryDataCommandHandler : IRequestHandler<BatteryDataCommand, BatteryDataResult>
    {
        private IRepository _repository;

        public BatteryDataCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<BatteryDataResult> Handle(BatteryDataCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = new BatteryData()
                {
                    Current = request.Current,
                    DateTime = request.DateTime,
                    DeviceId = request.DeviceId,
                    Status = (int)request.Status,
                    Voltage = request.Voltage,
                    VoltageCharger = request.VoltageCharger
                };
                await _repository.AddData(data, cancellationToken);

                return new() { Result = true };
            }
            catch 
            {
                return new() { Result = false }; 
            }
        }
    }
}
