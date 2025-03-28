using AutoMapper;
using MassTransit;
using Project.Module.DTOs;
using Project.Module.Model;
using Project.Module.Repository.Interface;
using Project.Module.Services.Interface;

namespace Project.Module.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProjectService(IProjectRepository repository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._publishEndpoint = publishEndpoint;
        }

        /// <summary>
        /// Get Project By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<ProjectModel> GetProjectById(int id)
        {
            var project = await this._repository.findByIdAsync(id);
            if (project == null)
                throw new KeyNotFoundException("project not found");

            return project;
        }
        /// <summary>
        /// List of All Project
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectModel>> ListOfProject()
        {
            return await this._repository.ListOfProjectAsync();
        }
        /// <summary>
        /// Save Project
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<ProjectModel> SaveProject(CreateProjectDTO body)
        {
            var project = this._mapper.Map<ProjectModel>(body);

            await this._repository.SaveProjectAsync(project);

            await this._publishEndpoint.Publish(new ProjectModel
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            });
            return project;
        }
    }
}
