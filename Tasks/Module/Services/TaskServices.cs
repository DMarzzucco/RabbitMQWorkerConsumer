using AutoMapper;
using Tasks.Module.DTOs;
using Tasks.Module.Model;
using Tasks.Module.Repository.Interface;
using Tasks.Module.Services.Interface;

namespace Tasks.Module.Services
{
    public class TaskServices : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskServices(ITaskRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        /// <summary>
        /// Create Task
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TaskModel> CreateTask(CreateTaskDTO body)
        {
            var task = this._mapper.Map<TaskModel>(body);
            await this._repository.SaveTaskAsync(task);
            return task;
        }
        /// <summary>
        /// Find Task By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TaskModel> FindTaskById(int id)
        {
            var task = await this._repository.findByIdAsync(id);
            if (task == null) throw new KeyNotFoundException("task not found");
            return task;
        }
        /// <summary>
        /// List of All Task
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<TaskModel>> ListOfALlTask()
        {
            return await this._repository.ListOfAllTask();
        }
    }
}
