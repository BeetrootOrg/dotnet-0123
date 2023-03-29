using System;
using System.Collections.Generic;

using Calendar.Contracts;
using Calendar.Domain.Repositories;
using Calendar.Domain.Services;

using Moq;

namespace Calendar.UnitTests
{
    public class MeetingServiceTests
    {
        private readonly Mock<IRepository> _repository;

        private readonly IMeetingService _meetingService;

        public MeetingServiceTests()
        {
            _repository = new Mock<IRepository>();
            _meetingService = new MeetingService(_repository.Object);
        }

        [Fact]
        public void GetAllMeetingsShouldReturnMeetingsFromRepository()
        {
            Meeting[] meetings = new[]
            {
                new Meeting
                {
                    Name = "Meeting 1",
                    Start = new DateTime(2020, 1, 1, 10, 0, 0),
                    Duration = new TimeSpan(1, 0, 0),
                    Room = new Room { Name = "Room 1" }
                },
                new Meeting
                {
                    Name = "Meeting 2",
                    Start = new DateTime(2020, 1, 1, 11, 0, 0),
                    Duration = new TimeSpan(1, 0, 0),
                    Room = new Room { Name = "Room 2" }
                }
            };

            _ = _repository.Setup(x => x.GetAllMeetings()).Returns(meetings);

            IEnumerable<Meeting> result = _meetingService.GetAllMeetings();

            Assert.Equal(meetings, result);
        }
    }
}