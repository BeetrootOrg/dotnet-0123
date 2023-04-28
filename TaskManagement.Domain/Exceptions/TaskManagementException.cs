using System;

namespace TaskManagement.Domain.Exceptions
{
    public enum TaskManagementError
    {
        TaskStatusIsNotNew,
        TaskAlreadyAssignedToUser,
    }

    public class TaskManagementException : Exception
    {
        public TaskManagementError Error { get; }

        public TaskManagementException(TaskManagementError error, string message) : base(message)
        {
            Error = error;
        }
    }
}