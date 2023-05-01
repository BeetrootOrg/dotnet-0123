using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using TaskManagement.Contracts.Http;
using TaskManagement.Domain.Exceptions;

namespace TaskManagement.Api.Filters
{
    public class TaskManagementExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is TaskManagementException exception)
            {
                context.Result = exception.Error switch
                {
                    TaskManagementError.TaskNotFound => new NotFoundObjectResult(new ErrorModel
                    {
                        Message = exception.Message,
                    }),
                    TaskManagementError.TaskStatusIsNotNew => new BadRequestObjectResult(new ErrorModel
                    {
                        Message = exception.Message,
                    }),
                    TaskManagementError.TaskAlreadyAssignedToUser => new BadRequestObjectResult(new ErrorModel
                    {
                        Message = exception.Message,
                    }),
                    TaskManagementError.TaskStatusCannotBeChanged => new BadRequestObjectResult(new ErrorModel
                    {
                        Message = exception.Message,
                    }),
                    _ => throw new ArgumentOutOfRangeException(nameof(context), exception.Error, null),
                };
            }
        }
    }
}