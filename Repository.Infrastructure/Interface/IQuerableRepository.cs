using DataModel.Infrastructure;
using System.Collections.Generic;
using ViewModel.Views;

namespace Repository.Infrastructure.Interface
{
    public interface IQuerableRepository
    {
        T GetSingle<T>(string query, BaseParamModel prms);
        List<T> GetList<T>(string query, BaseParamModel prms); 
    }
}
