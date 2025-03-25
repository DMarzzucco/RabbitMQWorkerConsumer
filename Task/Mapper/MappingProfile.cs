using AutoMapper;
using Task.Module.DTOs;
using Task.Module.Model;

namespace Task.Mapper
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
