using Microsoft.EntityFrameworkCore;
using Tasks.Context;
using Tasks.Module.Model;
using Tasks.Module.Repository.Interface;

namespace Tasks.Module.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDBContext _context;
        public TaskRepository(AppDBContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Find By Id Async 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TaskModel?> findByIdAsync(int id)
        {
            return await this._context.TaskModel.FindAsync(id);
        }
        /// <summary>
        /// List of All Task
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TaskModel>> ListOfAllTask()
        {
            return await this._context.TaskModel.ToListAsync();
        }
        /// <summary>
        /// Save Task Async
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task SaveTaskAsync(TaskModel task)
        {
            this._context.TaskModel.Add(task);
            await this._context.SaveChangesAsync();
        }
    }
}
