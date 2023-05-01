using System;

namespace TaskManagement.Domain.Exceptions
{
    public enum TaskManagementError
    {
        TaskNotFound,
        TaskStatusIsNotNew,
        TaskAlreadyAssignedToUser,
        TaskStatusCannotBeChanged,
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