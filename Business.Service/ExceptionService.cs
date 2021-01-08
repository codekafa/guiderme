using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Newtonsoft.Json;
using Repository.Base;
using System;

namespace Business.Service
{
    public class ExceptionService : IExceptionManager
    {

        IUnitOfWork _uow;
        public ExceptionService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public long HandleException(Exception ex)
        {
            var exp = new ExceptionLog();
            exp.ExceptionResult = JsonConvert.SerializeObject(ex);
            _uow.ExceptionLogRepository.Add(exp);
            _uow.SaveChanges();
            return exp.ID;
        }


        public ExceptionLog GetException(long id)
        {
            return _uow.ExceptionLogRepository.Get(x => x.ID == id);
        }

    }
}
