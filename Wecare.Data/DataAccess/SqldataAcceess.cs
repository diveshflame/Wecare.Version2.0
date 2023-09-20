using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeCare.Data.DataAccess
{
    public class SqldataAccess : ISqldataAccess
    {
        private readonly IConfiguration _config;

        public SqldataAccess() : this(null)
        {

        }


        public SqldataAccess(IConfiguration config)
        {
            _config = config;
           
        }
        string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=007;Database=WeCareDB;";
        public async Task<IEnumerable<T>> LoadData<T, U>(string sqlCommand, U parameters, string ConnectionId)
        {
           
                using IDbConnection connection = new NpgsqlConnection(connectionString);
                return await connection.QueryAsync<T>(sqlCommand, parameters);
            
        }

        public async Task SaveData<T>(string sqlCommand, T parameters, string ConnectionId = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(ConnectionId));
            await connection.ExecuteAsync(sqlCommand, parameters);

        }


    }
}
