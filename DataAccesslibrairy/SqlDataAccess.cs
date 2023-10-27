using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccesslibrairy
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connexionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connexion = new SqlConnection(connexionString))
            {
                var data = await connexion.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }

        public async Task SaveData<T, U>(string sql, U parameters)
        {
            string connexionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connexion = new SqlConnection(connexionString))
            {
                await connexion.ExecuteAsync(sql, parameters);
            }


        }

    }
}