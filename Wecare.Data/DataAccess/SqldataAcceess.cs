using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using System.Data;
using System.Configuration;


namespace WeCare.Data.DataAccess
{
    public class SqldataAccess : ISqldataAccess
    {
        private readonly IConfiguration _config;

        public SqldataAccess():this(null)
        {

        }
        public SqldataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T,U>(string sqlCommand, U parameters, string ConnectionId ="Default")
        {
            try
            {
                using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(ConnectionId));
                var LoadData = await connection.QueryAsync<T>(sqlCommand, parameters);

                return LoadData;
            }
            catch (Exception ex) { throw; }

        }

        public async Task SaveData<T>(string sqlCommand, T parameters, string ConnectionId = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(ConnectionId));
             await connection.ExecuteAsync(sqlCommand, parameters);
          
        }

    
    }
}
