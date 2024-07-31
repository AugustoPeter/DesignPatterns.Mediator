using Dapper;
using DesignPatterns.Mediator.Data.Shared;
using DesignPatterns.Mediator.Domain.DomainObjects;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DesignPatterns.Mediator.Data.Repository.Shared;

public class DapperRepository<T>(IConfiguration configuration)
    : IDapperRepository<T> where T : class, IAggregateRoot
{
    public async Task<IList<T>> QueryAsync(string sql, CancellationToken cancellationToken = default)
    {
        await using var connection = new SqlConnection(configuration.GetConnectionString("OperationContext"));
        try
        {
            await connection.OpenAsync(cancellationToken);
            var result = await connection.QueryAsync<T>(sql, cancellationToken);

            return result.ToList();
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                await connection.CloseAsync();
        }
    }

    public async Task<IList<T2>> QueryAsync<T2>(string sql, CancellationToken cancellationToken = default)
    {
        await using var connection = new SqlConnection(configuration.GetConnectionString("OperationContext"));
        try
        {
            await connection.OpenAsync(cancellationToken);
            var result = await connection.QueryAsync<T2>(sql, cancellationToken);

            return result.ToList();
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                await connection.CloseAsync();
        }
    }

    public async Task<T> ExecuteScalarAsync(string sql, CancellationToken cancellationToken = default)
    {
        await using var connection = new SqlConnection(configuration.GetConnectionString("OperationContext"));
        try
        {
            await connection.OpenAsync(cancellationToken);
            var result = await connection.ExecuteScalarAsync<T>(sql, cancellationToken);

            return result;
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                await connection.CloseAsync();
        }
    }

    public async Task<T2> ExecuteScalarAsync<T2>(string sql, CancellationToken cancellationToken = default)
    {
        await using var connection = new SqlConnection(configuration.GetConnectionString("OperationContext"));
        try
        {
            await connection.OpenAsync(cancellationToken);
            var result = await connection.ExecuteScalarAsync<T2>(sql, cancellationToken);

            return result;
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                await connection.CloseAsync();
        }
    }

    public async Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken = default)
    {
        await using var connection = new SqlConnection(configuration.GetConnectionString("OperationContext"));
        try
        {
            await connection.OpenAsync(cancellationToken);
            return await connection.ExecuteAsync(sql, cancellationToken);
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
                await connection.CloseAsync();

        }
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
    }
}
