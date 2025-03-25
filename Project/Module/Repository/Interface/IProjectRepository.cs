using Project.Module.Model;

namespace Project.Module.Repository.Interface
{
    public interface IProjectRepository
    {
        Task SaveProjectAsync(ProjectModel body);
        Task<IEnumerable<ProjectModel>> ListOfProjectAsync();
        Task<ProjectModel?> findByIdAsync(int id);
    }
}
