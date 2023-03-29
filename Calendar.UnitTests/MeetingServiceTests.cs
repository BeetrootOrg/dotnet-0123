using System;
using System.Collections.Generic;
using System.Linq;

using Bogus;

using Calendar.Contracts;
using Calendar.Domain.Repositories;
using Calendar.Domain.Services;

using Moq;

using Shouldly;

namespace Calendar.UnitTests
{
    public class MeetingServiceTests
    {
        private readonly Mock<IRepository> _repository;

        private readonly IMeetingService _meetingService;

        private readonly Faker<Meeting> _meetingFaker;

        public MeetingServiceTests()
        {
            _repository = new Mock<IRepository>();
            _meetingService = new MeetingService(_repository.Object);

            _meetingFaker = new Faker<Meeting>()
                .RuleFor(m => m.Duration, f => f.Date.Timespan(TimeSpan.FromHours(2)))
                .RuleFor(m => m.Start, f => f.Date.Future())
                .RuleFor(m => m.Name, f => f.Database.Random.Guid().ToString())
                .RuleFor(m => m.Room, f => new Room { Name = f.Database.Random.Guid().ToString() });

        }

        [Fact]
        public void GetAllMeetingsShouldReturnMeetingsFromRepository()
        {
            IEnumerable<Meeting> meetings = _meetingFaker.GenerateBetween(5, 15);
            _ = _repository.Setup(x => x.GetAllMeetings()).Returns(meetings);

            IEnumerable<Meeting> result = _meetingService.GetAllMeetings();

            meetings.ShouldBe(result);
        }

        [Fact]
        public void AddMeetingShouldAddItSuccessfullyIfNoMeeting()
        {
            Meeting meeting = _meetingFaker.Generate();
            _ = _repository.Setup(x => x.GetAllMeetings()).Returns(Enumerable.Empty<Meeting>());

            _meetingService.AddMeeting(meeting);

            _repository.Verify(x => x.AddMeeting(meeting), Times.Once());
        }
    }
}