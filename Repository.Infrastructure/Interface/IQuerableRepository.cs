using DataModel.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Views;

namespace Repository.Infrastructure.Interface
{
    public interface IQuerableRepository
    {
        T GetSingle<T>(string query, BaseParamModel prms);
        List<T> GetList<T>(string query, BaseParamModel prms);

        int ExecuteQuery(string query, BaseParamModel prms);

        Task<int> ExecuteQueryASync(string query, BaseParamModel prms);
    }
}
