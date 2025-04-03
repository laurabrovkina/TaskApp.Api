using TaskApp.Api.Domain;
using TaskApp.Api.Models;

namespace TaskApp.Api.Services;

public class TaskService : ITaskService
{
    private TaskRepository _taskRepository;

    public TaskService(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task Create(CreateTask task)
    {
        await _taskRepository.Create(new TaskToDo
        {
            Id = task.Id,
            Title = task.Title,
            Done = task.Done
        });
    }

    public async Task<IEnumerable<GetTask>> GetAllAsync()
    {
        var result = await _taskRepository.GetAllAsync();
        
        return result.Select(x => new GetTask
        {
            Id = x.Id,
            Title = x.Title,
            Done = x.Done
        });
    }

    public async Task Delete(Guid id)
    {
        await _taskRepository.Delete(id);
    }
}