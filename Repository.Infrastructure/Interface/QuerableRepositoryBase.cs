using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Pomelo.EntityFrameworkCore.MySql;
using ViewModel.Views;
using Dapper;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Repository.Infrastructure.Interface
{
    extern alias MySqlConnectorAlias;
    public class QuerableRepositoryBase : IQuerableRepository
    {

        AppSettings _appSettings;
        public QuerableRepositoryBase(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public int ExecuteQuery(string query, BaseParamModel prms)
        {
            using var con = new MySqlConnection(_appSettings.DefaultConnection);
            con.Open();
            using var cmd = new MySqlCommand(query, con);
            int value = cmd.ExecuteNonQuery();
            con.Close();
            return value;
        }

        public Task<int> ExecuteQueryASync(string query, BaseParamModel prms)
        {
            using var con = new MySqlConnection(_appSettings.DefaultConnection);
            con.Open();
            using var cmd = new MySqlCommand(query, con);
            var value = cmd.ExecuteNonQueryAsync();
            con.Close();
            return value;
        }

        public List<T> GetList<T>(string query, BaseParamModel prms)
        {
            using (var connection = new MySqlConnectorAlias::MySql.Data.MySqlClient.MySqlConnection(_appSettings.DefaultConnection))
            {
                return connection.Query<T>(query, prms).ToList();
            }
        }

        public T GetSingle<T>(string query, BaseParamModel prms)
        {
            using (var connection = new MySqlConnectorAlias::MySql.Data.MySqlClient.MySqlConnection(_appSettings.DefaultConnection))
            {
                return connection.QueryFirstOrDefault<T>(query, prms);
            }
        }

    }
}
