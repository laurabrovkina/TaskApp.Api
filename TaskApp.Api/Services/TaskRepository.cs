using Dapper;
using TaskApp.Api.Domain;
using TaskApp.Api.Persistence;
using Throw;

namespace TaskApp.Api.Services;

public class TaskRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public TaskRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task Create(TaskToDo task)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        const string query = @"
            INSERT INTO tasks(id, title, done)
            VALUES (@Id, @Title, @Done)";

        var result = await connection.ExecuteAsync(query, task);

        result.Throw().IfNegativeOrZero();
    }
    
    public async Task<IEnumerable<TaskToDo>> GetAllAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        const string query = "SELECT * FROM tasks";

        return await connection.QueryAsync<TaskToDo>(query);
    }

    public async Task Delete(Guid id)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        const string query = "DELETE FROM tasks WHERE id = @Id";

        var result = await connection.ExecuteAsync(query, new { Id = id });

        result.Throw().IfNegativeOrZero();
    }
}