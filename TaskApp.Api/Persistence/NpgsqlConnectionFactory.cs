﻿using System.Data;
using Npgsql;

namespace TaskApp.Api.Persistence;

public class NpgsqlConnectionFactory: IDbConnectionFactory
{
    private readonly string _connectionString;

    public NpgsqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_connectionString);

        await connection.OpenAsync();

        return connection;
    }
}
