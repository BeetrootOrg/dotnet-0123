using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Bogus;

using Calendar.Contracts;
using Calendar.Domain.Exceptions;
using Calendar.Domain.Repositories;
using Calendar.Domain.Services;

using Moq;

using Shouldly;

namespace Calendar.UnitTests
{
    public class AddMeetingShouldFailWithExceptionIfThereIsIntersectionData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new DateTime(2024, 01, 01),
                TimeSpan.FromHours(1),

                new DateTime(2024, 01, 01, 00, 30, 00),
                TimeSpan.FromHours(1),
            };

            yield return new object[]
            {
                new DateTime(2024, 01, 01, 00, 30, 00),
                TimeSpan.FromHours(1),

                new DateTime(2024, 01, 01),
                TimeSpan.FromHours(2),
            };

            yield return new object[]
            {
                new DateTime(2024, 01, 01),
                TimeSpan.FromHours(2),

                new DateTime(2024, 01, 01, 00, 30, 00),
                TimeSpan.FromMinutes(30),
            };

            yield return new object[]
            {
                new DateTime(2024, 01, 01, 00, 30, 00),
                TimeSpan.FromMinutes(30),

                new DateTime(2024, 01, 01),
                TimeSpan.FromHours(2),
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class AddMeetingShouldNotFailWithExceptionIfOneMeetingEndsWhenOtherStartsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new DateTime(2024, 01, 01, 1, 0, 0),
                TimeSpan.FromHours(1),

                new DateTime(2024, 01, 01),
                TimeSpan.FromHours(1),
            };

            yield return new object[]
            {
                new DateTime(2024, 01, 01),
                TimeSpan.FromHours(1),

                new DateTime(2024, 01, 01, 1, 0, 0),
                TimeSpan.FromHours(1),
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MeetingServiceTests
    {
        private readonly Mock<IRepository> _repository;

        private readonly IMeetingService _meetingService;

        private readonly Faker<Meeting> _meetingFaker;
        private readonly Faker _faker;

        public MeetingServiceTests()
        {
            _repository = new Mock<IRepository>();
            _meetingService = new MeetingService(_repository.Object);

            _meetingFaker = new Faker<Meeting>()
                .RuleFor(m => m.Duration, f => f.Date.Timespan(TimeSpan.FromHours(2)))
                .RuleFor(m => m.Start, f => f.Date.Future())
                .RuleFor(m => m.Name, f => f.Database.Random.Guid().ToString())
                .RuleFor(m => m.Room, f => new Room { Name = f.Database.Random.Guid().ToString() });

            _faker = new Faker();
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

        [Theory]
        [ClassData(typeof(AddMeetingShouldFailWithExceptionIfThereIsIntersectionData))]
        public void AddMeetingShouldFailWithExceptionIfThereIsIntersection(DateTime newMeetingStart,
            TimeSpan newMeetingDuration,
            DateTime existentMeetingStart,
            TimeSpan existentMeetingDuration)
        {
            string roomName = Guid.NewGuid().ToString();

            Meeting newMeeting = new()
            {
                Start = newMeetingStart,
                Duration = newMeetingDuration,
                Name = Guid.NewGuid().ToString(),
                Room = new Room
                {
                    Name = roomName
                }
            };

            Meeting[] existentMeetings = new Meeting[]
            {
                new Meeting
                {
                    Start = existentMeetingStart,
                    Duration = existentMeetingDuration,
                    Name = Guid.NewGuid().ToString(),
                    Room = new Room
                    {
                        Name = roomName
                    }
                }
            };

            _ = _repository.Setup(x => x.GetAllMeetings()).Returns(existentMeetings);

            Action act = () => _meetingService.AddMeeting(newMeeting);

            _ = act.ShouldThrow<CalendarException>();
            _repository.Verify(x => x.AddMeeting(It.IsAny<Meeting>()), Times.Never());
        }

        [Theory]
        [ClassData(typeof(AddMeetingShouldNotFailWithExceptionIfOneMeetingEndsWhenOtherStartsData))]
        public void AddMeetingShouldNotFailWithExceptionIfOneMeetingEndsWhenOtherStarts(DateTime newMeetingStart,
            TimeSpan newMeetingDuration,
            DateTime existentMeetingStart,
            TimeSpan existentMeetingDuration)
        {
            string roomName = Guid.NewGuid().ToString();

            Meeting newMeeting = new()
            {
                Start = newMeetingStart,
                Duration = newMeetingDuration,
                Name = Guid.NewGuid().ToString(),
                Room = new Room
                {
                    Name = roomName
                }
            };

            Meeting[] existentMeetings = new Meeting[]
            {
                new Meeting
                {
                    Start = existentMeetingStart,
                    Duration = existentMeetingDuration,
                    Name = Guid.NewGuid().ToString(),
                    Room = new Room
                    {
                        Name = roomName
                    }
                }
            };

            _ = _repository.Setup(x => x.GetAllMeetings()).Returns(existentMeetings);

            Action act = () => _meetingService.AddMeeting(newMeeting);

            act.ShouldNotThrow();
            _repository.Verify(x => x.AddMeeting(newMeeting), Times.Once());
        }

        [Fact]
        public void AddMeetingShouldNotThrowExceptionIfMeetingsIntersectButRoomsAreDifferent()
        {
            DateTime start = _faker.Date.Future();
            TimeSpan duration = _faker.Date.Timespan(TimeSpan.FromHours(2));

            Meeting newMeeting = new()
            {
                Start = start,
                Duration = duration,
                Name = Guid.NewGuid().ToString(),
                Room = new Room
                {
                    Name = Guid.NewGuid().ToString()
                }
            };

            Meeting[] existentMeetings = new Meeting[]
            {
                new Meeting
                {
                    Start = start,
                    Duration = duration,
                    Name = Guid.NewGuid().ToString(),
                    Room = new Room
                    {
                        Name = Guid.NewGuid().ToString()
                    }
                }
            };

            _ = _repository.Setup(x => x.GetAllMeetings()).Returns(existentMeetings);

            Action act = () => _meetingService.AddMeeting(newMeeting);

            act.ShouldNotThrow();
            _repository.Verify(x => x.AddMeeting(newMeeting), Times.Once());
        }
    }
}