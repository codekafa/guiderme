using DataModel.BaseEntities;
using System;

namespace Business.Service.Infrastructure
{
    public interface IExceptionManager
    {
        long HandleException(Exception ex);

        ExceptionLog GetException(long id);
    }
}
