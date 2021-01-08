using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Base
{
    public interface IUnitOfWork
    {

        IExecutionStrategy CreateExecuteStrategy();
        IDbContextTransaction BeginTransaction();
        void SaveChanges();
        bool Commit();
        void Rollback();

         ICityRepository CityRepository { get;  set; }
         ICountryRepository CountryRepository { get;  set; }
         ILexiconRepository LexiconRepository { get;  set; }
         INotificationRepository NotificationRepository { get;  set; }
         IOtpTransactionRepository OtpTransactionRepository { get;  set; }
         IPageRepository PageRepository { get;  set; }
         IRequestRepository RequestsRepository { get;  set; }
         IRequestBidRepository RequestBidRepository { get;  set; }
         IRequestPropertyRepository RequestPropertyRepository { get;  set; }
         IServiceCategoryPropertyRepository ServiceCategoryPropertyRepository { get;  set; }
         IServiceCategoryRepository ServiceCategoryRepository { get;  set; }
         IServicePhotoRepository ServicePhotoRepository { get;  set; }
         IUserRepository UserRepository { get;  set; }
         IServiceRepository ServiceRepository { get;  set; }
         IServiceRequestRelationRepository ServiceRequestRelationRepository { get;  set; }

        IExceptionLogRepository ExceptionLogRepository { get; set; }
        IGalleryRepository GalleryRepository { get; set; }
    }
}
