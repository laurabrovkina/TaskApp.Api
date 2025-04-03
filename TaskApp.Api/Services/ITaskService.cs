using TaskApp.Api.Models;

namespace TaskApp.Api.Services;

public interface ITaskService
{
    Task Create(CreateTask task);
    Task<IEnumerable<GetTask>> GetAllAsync();
    Task Delete(Guid id);
}