using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Module.Model;
using Project.Module.Repository.Interface;

namespace Project.Module.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDBContext _context;

        public ProjectRepository(AppDBContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// find by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProjectModel?> findByIdAsync(int id)
        {
            return await this._context.ProjectModel.FindAsync(id);
        }
        /// <summary>
        /// to list async 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectModel>> ListOfProjectAsync()
        {
            return await this._context.ProjectModel.ToListAsync();
        }
        /// <summary>
        /// Save project
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task SaveProjectAsync(ProjectModel body)
        {
            this._context.ProjectModel.Add(body);
            await this._context.SaveChangesAsync();
        }
    }
}
