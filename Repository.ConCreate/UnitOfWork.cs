using Data.BaseContext;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository.ConCreate
{
    public class UnitOfWork : IUnitOfWork
    {

        private ServiceBuilderContext _serviceBuilderContext;

        public UnitOfWork(ServiceBuilderContext context)
        {
            _serviceBuilderContext = context;
            ServiceRepository = new ServiceRepository(_serviceBuilderContext);
            ServiceRequestRelationRepository = new ServiceRequestRelationRepository(_serviceBuilderContext);
            CityRepository = new CityRepository(_serviceBuilderContext);
            CountryRepository = new CountryRepository(_serviceBuilderContext);
            LexiconRepository = new LexiconRepository(_serviceBuilderContext);
            NotificationRepository = new NotificationRepository(_serviceBuilderContext);
            OtpTransactionRepository = new OtpTransactionRepository(_serviceBuilderContext);
            PageRepository = new PageRepository(_serviceBuilderContext);
            RequestsRepository = new RequestRepository(_serviceBuilderContext);
            RequestBidRepository = new RequestBidRepository(_serviceBuilderContext);
            RequestBidRepository = new RequestBidRepository(_serviceBuilderContext);
            RequestPropertyRepository = new RequestPropertyRepository(_serviceBuilderContext);
            ServiceCategoryPropertyRepository = new ServiceCategoryPropertyRepository(_serviceBuilderContext);
            ServiceCategoryRepository = new ServiceCategoryRepository(_serviceBuilderContext);
            ServicePhotoRepository = new ServicePhotoRepository(_serviceBuilderContext);
            UserRepository = new UserRepository(_serviceBuilderContext);
            ServiceRequestRelationRepository = new ServiceRequestRelationRepository(_serviceBuilderContext);
        }

        public ICityRepository CityRepository { get; set; }
        public ICountryRepository CountryRepository { get; set; }
        public ILexiconRepository LexiconRepository { get; set; }
        public INotificationRepository NotificationRepository { get; set; }
        public IOtpTransactionRepository OtpTransactionRepository { get; set; }
        public IPageRepository PageRepository { get; set; }
        public IRequestRepository RequestsRepository { get; set; }
        public IRequestBidRepository RequestBidRepository { get; set; }
        public IRequestPropertyRepository RequestPropertyRepository { get; set; }
        public IServiceCategoryPropertyRepository ServiceCategoryPropertyRepository { get; set; }
        public IServiceCategoryRepository ServiceCategoryRepository { get; set; }
        public IServicePhotoRepository ServicePhotoRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IServiceRepository ServiceRepository { get; set; }
        public IServiceRequestRelationRepository ServiceRequestRelationRepository { get; set; }
        public IDbContextTransaction BeginTransaction()
        {
            return _serviceBuilderContext.Database.BeginTransaction();
        }
        public bool Commit()
        {
            try
            {
                _serviceBuilderContext.Database.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                Rollback();
                return false;
            }

        }
        public void Rollback()
        {
            _serviceBuilderContext.Database.RollbackTransaction();
        }
        public void SaveChanges()
        {
            _serviceBuilderContext.SaveChanges();
        }

        public IExecutionStrategy CreateExecuteStrategy()
        {
            return _serviceBuilderContext.Database.CreateExecutionStrategy();
        }
    }
}
