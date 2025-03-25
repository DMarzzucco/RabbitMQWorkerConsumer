using Task.Module.Model;

namespace Task.Module.Repository.Interface
{
    public interface ITaskRepositry
    {
        Task SaveTaskAsync (TaskModel task);
        
    }
}