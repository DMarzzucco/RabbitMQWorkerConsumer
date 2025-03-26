using AutoMapper;
using Tasks.Module.DTOs;
using Tasks.Module.Model;

namespace Tasks.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTaskDTO, TaskModel>();
            CreateMap<UpdateTaskDTO, TaskModel>();
        }
    }
}
