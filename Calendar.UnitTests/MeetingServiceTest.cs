
using Moq;
using Calendar.Domain;
using Calendar.Domain.Repositories;
using Calendar.Domain.Services;
using Calendar.Contracts;
using Bogus;
using Shouldly;

namespace Calendar.UnitTests
{
    public class MeetingServiceTest
    {
        private readonly Mock<IRepository> _repository;
        private readonly IMeetingService _meetingService;
        private readonly Faker<Meeting> _meetingFaker;
        public MeetingServiceTest()
        {
            _repository=new Mock<IRepository>();
            _meetingService = new MeetingService(_repository.Object);
            _meetingFaker=new();
        }
        [Fact]
        public void GetAllMeetingsShouldReturnAllMeetgsFromRepository()
        {
            // Given
            var meetings=new[]{
                new Meeting(){
                    Name="Meeting" , Start=System.DateTime.Now, Duration=new System.TimeSpan(0,30,0), Room=new Room(){ Name="room1"} 
                },
                new Meeting(){
                    Name="Meeting" , Start=System.DateTime.Now, Duration=new System.TimeSpan(0,30,0), Room=new Room(){ Name="room1"} 
                },
                new Meeting(){
                    Name="Meeting" , Start=System.DateTime.Now, Duration=new System.TimeSpan(0,30,0), Room=new Room(){ Name="room1"} 
                }
            };
            // When
            _repository.Setup(x=>x.GetAllMeetings()).Returns(meetings);
            // Then
            var result=_meetingService.GetAllMeetings();
            meetings.ShouldBe (result);
            Assert.Equal(meetings, result);
        }
    }
}