using AutoMapper;

using DatabaseTask = TaskManagement.Domain.Models.Database.Task;
using ContractsTask = TaskManagement.Contracts.Models.Task;

namespace TaskManagement.Domain.Profiles
{
    internal class TaskManagementProfile : Profile
    {
        public TaskManagementProfile()
        {
            _ = CreateMap<DatabaseTask, ContractsTask>()
                .ForMember(dest => dest.AssigneeEmail, src =>
                {
                    src.PreCondition(t => t.Assignee != null);
                    src.MapFrom(t => t.Assignee.Email);
                });
        }
    }
}