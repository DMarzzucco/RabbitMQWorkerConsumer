using Project.Module.DTOs;
using Project.Module.Model;

namespace Project.Module.Services.Interface
{
    public interface IProjectService
    {
        Task<ProjectModel> SaveProject(CreateProjectDTO body);
        Task<IEnumerable<ProjectModel>> ListOfProject();
        Task<ProjectModel> GetProjectById(int id);
    }
}
