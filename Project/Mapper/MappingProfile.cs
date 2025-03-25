using AutoMapper;
using Project.Module.DTOs;
using Project.Module.Model;

namespace Project.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProjectDTO, ProjectModel>();
            CreateMap<UpdateProjectDTO, ProjectModel>();
        }
    }
}
