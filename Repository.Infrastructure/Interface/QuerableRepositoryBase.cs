using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Pomelo.EntityFrameworkCore.MySql;
using ViewModel.Views;
using Dapper;
using System.Linq;

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
