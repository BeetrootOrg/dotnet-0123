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
                context.Result = new BadRequestObjectResult(new ErrorModel
                {
                    Message = exception.Message,
                });
            }
        }
    }
}