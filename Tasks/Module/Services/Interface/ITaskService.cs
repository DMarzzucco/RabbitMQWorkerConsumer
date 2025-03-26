using Tasks.Module.DTOs;
using Tasks.Module.Model;

namespace Tasks.Module.Services.Interface
{
    public interface ITaskService
    {
        Task<TaskModel> CreateTask(CreateTaskDTO body);
        Task<IEnumerable<TaskModel>> ListOfALlTask();
        Task<TaskModel> FindTaskById(int id);
    }
}
