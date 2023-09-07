using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using System.Data;

namespace WeCare.Data.DataAccess
{
    public class SqldataAccess : ISqldataAccess
    {
        private readonly IConfiguration _config;

        public SqldataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T,U>(string sqlCommand, U parameters, string ConnectionId = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(ConnectionId));
            return await connection.QueryAsync<T>(sqlCommand, parameters);

         }

        public async Task SaveData<T>(string sqlCommand, T parameters, string ConnectionId = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(ConnectionId));
             await connection.ExecuteAsync(sqlCommand, parameters);
          
        }

    
    }
}
