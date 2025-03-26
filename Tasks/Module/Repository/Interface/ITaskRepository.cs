using Tasks.Module.Model;

namespace Tasks.Module.Repository.Interface
{
    public interface ITaskRepository
    {
        Task SaveTaskAsync (TaskModel task);
        Task<IEnumerable<TaskModel>> ListOfAllTask();
        Task<TaskModel?> findByIdAsync(int id);
    }
}