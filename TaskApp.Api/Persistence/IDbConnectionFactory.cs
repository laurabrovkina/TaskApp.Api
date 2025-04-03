using System.Data;

namespace TaskApp.Api.Persistence;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}