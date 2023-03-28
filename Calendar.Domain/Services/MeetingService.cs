using System;
using System.Collections.Generic;
using Calendar.Contracts;
using Calendar.Domain.Exceptions;
using Calendar.Domain.Repositories;

namespace Calendar.Domain.Services
{
    internal class MeetingService : IMeetingService
    {
        private readonly IRepository _repository;

        public MeetingService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddMeeting(Meeting meeting)
        {
            IEnumerable<Meeting> meetings = GetAllMeetings();
            if (DoesIntersectWithOther(meetings, meeting))
            {
                throw new CalendarException("Meeting intersect with other!");
            }

            _repository.AddMeeting(meeting);
        }

        public void UpdateMeeting(Meeting meeting, string oldName)
        {
            IEnumerable<Meeting> meetings = GetAllMeetings();
            
            if (DoesIntersectWithOther(meetings, meeting, oldName))
            {
                throw new CalendarException("Meeting intersect with other!");
            }

            _repository.UpdateMeeting(meeting, oldName);
        }

        public IEnumerable<Meeting> GetAllMeetings()
        {
            return _repository.GetAllMeetings();
        }

        private static bool DoesIntersectWithOther(IEnumerable<Meeting> meetings, Meeting meeting, string oldName = null)
        {
            foreach ((_, DateTime start, TimeSpan duration, Room room) in meetings)
            {
                if (meeting.Name == oldName)
                {
                    continue;
                }
                
                if (meeting.Room == room)
                {
                    DateTime end1 = meeting.Start.Add(meeting.Duration);
                    DateTime end2 = start.Add(duration);

                    if (meeting.Start >= start && meeting.Start < end2)
                    {
                        return true;
                    }

                    if (start >= meeting.Start && start < end1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public void SetBuffer(string buffer)
        {
            _repository.SetBuffer(buffer); 
        }

        public string GetBuffer()
        {
            return _repository.GetBuffer();
        }
    }
}