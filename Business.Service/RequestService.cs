using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ViewModel.Views;
using ViewModel.Views.Notification;
using ViewModel.Views.Request;
using ViewModel.Views.Service;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class RequestService : IRequestService
    {

        IQuerableRepository _queryRepo;
        IUnitOfWork _uow;
        ILexiconService _lexService;
        INotificationService _notifyService;
        IExceptionManager _exceptionManager;
        IServiceService _serviceService;
        public RequestService(IQuerableRepository querableRepository, IUnitOfWork unitOfWork, ILexiconService lexiconService, INotificationService notifyService, IExceptionManager exceptionManager, IServiceService serviceService)
        {
            _queryRepo = querableRepository;
            _uow = unitOfWork;
            _lexService = lexiconService;
            _notifyService = notifyService;
            _exceptionManager = exceptionManager;
            _serviceService = serviceService;
        }
        public CommonResult AddNewRequest(NewRequestModel request)
        {
            CommonResult result = new CommonResult();

            var strategy = _uow.CreateExecuteStrategy();
            strategy.Execute(() =>
          {
              using (var ts = _uow.BeginTransaction())
              {
                  try
                  {
                      Request sReq = new Request();
                      sReq.CityID = request.CityId;
                      sReq.CountryID = request.CountryId;
                      sReq.IsPublish = request.IsPublish;
                      sReq.ServiceCategoryID = request.CategoryId;
                      sReq.Description = request.Description;
                      if (request.IsPublish)
                      {
                          sReq.StartDate = DateTime.Now;
                          sReq.FinishDate = DateTime.Now.AddDays(2);
                      }
                      else
                      {
                          sReq.StartDate = null;
                          sReq.FinishDate = null;
                      }

                      sReq.UserID = request.UserId;
                      sReq = _uow.RequestsRepository.Add(sReq);

                      _uow.SaveChanges();
                      if (request.Properties != null)
                      {
                          foreach (var item in request.Properties)
                          {
                              RequestProperty prop = new RequestProperty();
                              prop.IsActive = true;
                              prop.ServiceCategoryPropertyID = item.Id;
                              prop.ServiceRequestID = sReq.ID;
                              prop.UserID = sReq.UserID;
                              prop.Value = item.Value;
                              _uow.RequestPropertyRepository.Add(prop);
                          }
                          _uow.SaveChanges();
                      }

                      var user = _uow.UserRepository.Get(x => x.ID == sReq.UserID);

                      if (user.UserType == (int)UserTypes.Servicer)
                      {
                          user.UserType = (int)UserTypes.ServicerEndEmployer;
                          _uow.UserRepository.Update(user);
                      }
                      _uow.SaveChanges();
                      if (sReq.IsPublish)
                      {
                          result = _serviceService.AddRelationsAndNotificationsRequestByServices(sReq.ServiceCategoryID, sReq.ID);

                          if (!result.IsSuccess)
                          {
                              throw new Exception(result.Message);
                             
                          }

                      }

                      string urlB = "/booking-detail?booking_id=" + sReq.ID;
                      string descriptionB = _lexService.GetTextValue("_your_booking_created_successfuly", 23);
                      _notifyService.AddNotification(new NewNotificationModel { Description = descriptionB, Url = urlB, UserID = user.ID });
                      _uow.SaveChanges();
                      _uow.Commit();
                      result.IsSuccess = true;
                      result.Message = _lexService.GetAlertSring("added_new_booking_successfuly", null);
                  }
                  catch (Exception ex)
                  {
                      _uow.Rollback();
                      result.IsSuccess = false;
                      _exceptionManager.HandleException(ex);
                      result.Message = ex.Message;
                  }
              }
          });

            return result;

        }
        public CommonResult AddNewRequestWitoutTransaction(NewRequestModel request)
        {
            CommonResult result = new CommonResult();

            try
            {
                Request sReq = new Request();
                sReq.CityID = request.CityId;
                sReq.CountryID = request.CountryId;
                sReq.IsPublish = request.IsPublish;
                sReq.ServiceCategoryID = request.CategoryId;
                sReq.Description = request.Description;
                if (request.IsPublish)
                {
                    sReq.StartDate = DateTime.Now;
                    sReq.FinishDate = DateTime.Now.AddDays(2);
                }
                else
                {
                    sReq.StartDate = null;
                    sReq.FinishDate = null;
                }

                sReq.UserID = request.UserId;
                sReq = _uow.RequestsRepository.Add(sReq);

                _uow.SaveChanges();
                if (request.Properties != null)
                {
                    foreach (var item in request.Properties)
                    {
                        RequestProperty prop = new RequestProperty();
                        prop.IsActive = true;
                        prop.ServiceCategoryPropertyID = item.Id;
                        prop.ServiceRequestID = sReq.ID;
                        prop.UserID = sReq.UserID;
                        prop.Value = item.Value;
                        _uow.RequestPropertyRepository.Add(prop);
                    }
                }

                var user = _uow.UserRepository.Get(x => x.ID == sReq.UserID);

                if (user.UserType == (int)UserTypes.Servicer)
                {
                    user.UserType = (int)UserTypes.ServicerEndEmployer;
                    _uow.UserRepository.Update(user);
                }

                var serviceList = _uow.ServiceRepository.GetList(x => x.IsActive == true && x.ServiceCategoryID == sReq.ServiceCategoryID);

                foreach (var service in serviceList)
                {
                    var requestDb = _uow.ServiceRequestRelationRepository.Add(new ServiceRequestRelation { IsActive = true, ServiceCategoryID = service.ServiceCategoryID, ServiceID = service.ID, ServiceUserID = service.UserID, ServiceRequestID = sReq.ID, Status = (int)ServiceRequestRelationStatus.Waiting });

                    string url = "/booking-view?request_id=" + requestDb.ID;
                    string description = _lexService.GetTextValue("_new_service_booking_created", 23);
                    _notifyService.AddNotificationSync(new NewNotificationModel { Description = description, Url = url, UserID = requestDb.ServiceUserID });
                }

                string urlB = "/booking-detail?booking_id=" + sReq.ID;
                string descriptionB = _lexService.GetTextValue("_your_booking_created_successfuly", 23);

                _notifyService.AddNotificationSync(new NewNotificationModel { Description = descriptionB, Url = urlB, UserID = user.ID });

                _uow.SaveChanges();
                _uow.Commit();
                result.IsSuccess = true;
                result.Message = _lexService.GetAlertSring("added_new_booking_successfuly", null);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                _exceptionManager.HandleException(ex);
            }

            return result;

        }
        public CommonResult AddOrEditRequest(AddOrEditRequestModel request)
        {
            throw new NotImplementedException();
        }
        public RequestDetailModel GetBookingDetailForView(long request_id, long currentUserId)
        {
            var search = new RequestSearchModel { p0 = request_id, CurrentUserId = currentUserId };

            string query = @"select 
                                    co.Name as CountryName,
                                    ci.Name as CityName,
                                    co.ID as CountryID,
                                    ci.ID as CityID,
                                    sc.ID as ServiceCategoryID,
                                    sc.CategoryPhoto,
                                    sc.Name as CategoryName,
                                    sr.CreateDate,
                                    sr.StartDate,
                                    sr.FinishDate,
                                    sr.IsPublish,
                                    sr.Description,
                                    sr.ID,
                                    sr.UserID
                                     from requests sr
                                    inner join servicecategories sc on sc.Id = sr.ServiceCategoryID
                                    inner join users u on u.Id = sr.UserID 
                                    inner join countries co on co.ID = sr.CountryID
                                    inner join cities ci on ci.ID = sr.CityID 
                                    where sr.ID = @p0 and sr.UserID = @CurrentUserID";

            var detail = _queryRepo.GetSingle<RequestDetailModel>(query, search);

            if (detail == null)
                return detail;

            detail.Properties = new List<RequestPorpertyModel>();

            string queryProps = @"SELECT srp.ID, srp.Value, scp.name FROM servicebuilder.requestproperties srp
                                    inner join servicecategoryproperties scp on scp.id = srp.ServiceCategoryPropertyID
                                    where srp.ServiceRequestID = @p0";

            detail.Properties = _queryRepo.GetList<RequestPorpertyModel>(queryProps, search);

            detail.Bids = new List<RequestBidListModel>();

            string queryBids = @"SELECT 
                                        s.Photo as ServicePhoto,
                                        CONCAT(u.FirstName ,' ', u.LastName ) as BidUserName,
                                        rb.ServiceCost,
                                        rb.CreateDate,
                                        rb.ServiceID,
                                        s.Name as ServiceName,
                                        rb.ID
                                         FROM servicebuilder.requestbids rb
                                        inner join services s on s.ID = rb.ServiceID
                                        inner join users u on u.ID = rb.BidUserID
                                        where rb.ServiceRequestID = @p0";

            detail.Bids = _queryRepo.GetList<RequestBidListModel>(queryBids, search);

            return detail;
        }
        public CommonResult GetMyRequestList(RequestSearchModel search)
        {

            CommonResult result = new CommonResult();

            string query = @"select 
                                    sc.CategoryPhoto,
                                    sc.Name as CategoryName,
                                    sr.CreateDate,
                                    sr.StartDate,
                                    sr.FinishDate,
                                    sr.IsPublish,
                                    sr.ID,
                                    co.Name as CountryName,
                                    ci.Name  as CityName,
                                    (select COUNT(rb.ID) from requestbids rb where rb.ServiceRequestID = sr.ID) as BidCount
                                     from requests sr
                                    inner join servicecategories sc on sc.Id = sr.ServiceCategoryID
                                    inner join users u on u.Id = sr.UserID 
                                    inner join countries co on co.ID = sr.CountryID
                                    inner join cities ci on ci.ID = sr.CityID
                                    
                                    where sr.IsActive = 1 and u.ID = @UserID and FinishDate > NOW() and IsPublish = 1 ";

            if (search.ServiceCategoryID.HasValue)
                query += "  and sr.ServiceCategoryID = @ServiceCategoryID";

            query += " ORDER BY  sr.ID DESC";

            query += " LIMIT  " + search.PageIndex * search.TakeRow + "," + search.TakeRow;



            var list = _queryRepo.GetList<RequestListModel>(query, search);

            string queryCount = @"select 
                                    COUNT(sr.ID)
                                     from requests sr
                                    inner join servicecategories sc on sc.Id = sr.ServiceCategoryID
                                    inner join users u on u.Id = sr.UserID where sr.IsActive = 1 and u.ID = @UserID";

            if (search.ServiceCategoryID.HasValue)
                queryCount += "  and sr.ServiceCategoryID = @ServiceCategoryID";

            long count = _queryRepo.GetSingle<long>(queryCount, search);

            result.DataCount = count;

            long k = count % 10;

            if (k > 0)
                count = (count / 20) + 1;

            result.IsSuccess = true;
            result.Data = list;
            result.PageCount = count;
            result.SelectedPage = search.PageIndex;
            return result;
        }
        public CommonResult GetMyRequestHistoryList(RequestSearchModel search)
        {

            CommonResult result = new CommonResult();

            string query = @"select 
                                    sc.CategoryPhoto,
                                    sc.Name as CategoryName,
                                    sr.CreateDate,
                                    sr.StartDate,
                                    sr.FinishDate,
                                    sr.IsPublish,
                                    sr.ID,
                                    co.Name as CountryName,
                                    ci.Name  as CityName,
                                    (select COUNT(rb.ID) from RequestBids rb where rb.ServiceRequestID = sr.ID) as BidCount
                                     from requests sr
                                    inner join servicecategories sc on sc.Id = sr.ServiceCategoryID
                                    inner join users u on u.Id = sr.UserID 
                                    inner join countries co on co.ID = sr.CountryID
                                    inner join cities ci on ci.ID = sr.CityID
                                    where sr.IsActive = 1 and u.ID = @UserID and FinishDate < NOW() and IsPublish = 0";

            if (search.ServiceCategoryID.HasValue)
                query += "  and sr.ServiceCategoryID = @ServiceCategoryID";

            query += " ORDER BY  sr.ID DESC";

            query += " LIMIT  " + search.PageIndex * search.TakeRow + "," + search.TakeRow;


            var list = _queryRepo.GetList<RequestListModel>(query, search);

            string queryCount = @"select 
                                    COUNT(sr.ID)
                                     from requests sr
                                    inner join servicecategories sc on sc.Id = sr.ServiceCategoryID
                                    inner join users u on u.Id = sr.UserID where sr.IsActive = 1 and u.ID = @UserID and FinishDate < NOW() and IsPublish = 0";

            if (search.ServiceCategoryID.HasValue)
                queryCount += "  and sr.ServiceCategoryID = @ServiceCategoryID";

            long count = _queryRepo.GetSingle<long>(queryCount, search);

            result.DataCount = count;

            long k = count % 10;

            if (k > 0)
                count = (count / 20) + 1;

            result.IsSuccess = true;
            result.Data = list;
            result.PageCount = count;
            result.SelectedPage = search.PageIndex;
            return result;
        }
        public CommonResult RemoveRequest(long request_id, long user_id)
        {
            CommonResult result = new CommonResult();
            try
            {
                var exist = _uow.RequestsRepository.Get(x => x.ID == request_id && x.UserID == user_id);

                if (exist == null)
                {
                    result.IsSuccess = false;
                    result.Message = _lexService.GetAlertSring("_booking_not_found", null);
                    return result;
                }

                exist.IsActive = false;
                _uow.RequestsRepository.Update(exist);
                _uow.SaveChanges();
                result.IsSuccess = true;
                result.Message = _lexService.GetAlertSring("_booking_removed_successfuly", null);
                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                _exceptionManager.HandleException(ex);
                return result;
            }
        }
        public CommonResult AvaibleRequests(BaseParamModel search)
        {
            CommonResult result = new CommonResult();
            string query = @"SELECT sr.ID, 
                        r.ID as RequestID,
                        co.Name as CountryName,
                        c.Name as CityName,
                        sca.Name as ServiceName,
                        ru.FirstName as RequestUserName,
                        r.FinishDate
                         FROM servicebuilder.servicerequestrelations sr
                        inner join requests r on r.ID = sr.ServiceRequestID
                        inner join countries co on co.ID = r.CountryID
                        inner join cities c on c.ID = r.CityID
                        inner join  users bu on bu.ID = sr.ServiceUserID
                        inner join services sc on sc.ServiceCategoryID = sr.ServiceCategoryID
                        inner join servicecategories sca on sca.ID = sc.ServiceCategoryID
                        inner join users ru on ru.ID = r.UserID
                        where bu.ID = @CurrentUserID and bu.IsActive = 1 and r.FinishDate > NOW() and r.IsPublish = 1 and r.IsActive = 1";

            query += " ORDER BY  sr.CreateDate DESC";

            query += " LIMIT  " + search.PageIndex * search.TakeRow + "," + search.TakeRow;

            var list = _queryRepo.GetList<AvaibleRequestListModel>(query, search);

            string queryCount = @"SELECT COUNT(sr.ID)
                         FROM servicebuilder.servicerequestrelations sr
                        inner join requests r on r.ID = sr.ServiceRequestID
                        inner join countries co on co.ID = r.CountryID
                        inner join cities c on c.ID = r.CityID
                        inner join  users bu on bu.ID = sr.ServiceUserID
                        inner join services sc on sc.ServiceCategoryID = sr.ServiceCategoryID
                        inner join servicecategories sca on sca.ID = sc.ServiceCategoryID
                        inner join users ru on ru.ID = r.UserID
                        where bu.ID = @CurrentUserID and bu.IsActive = 1 and r.FinishDate > NOW() and r.IsPublish = 1 and r.IsActive = 1";
            long count = _queryRepo.GetSingle<long>(queryCount, search);

            result.DataCount = count;

            long k = count % 10;

            if (k > 0)
                count = (count / 10) + 1;
            result.IsSuccess = true;
            result.Data = list;
            result.PageCount = count;
            result.SelectedPage = search.PageIndex;
            return result;

        }

        public async Task<CommonResult> PublishWaitingRequests(long userId)
        {
            CommonResult result = new CommonResult();
            try
            {
                var requests = _uow.RequestsRepository.GetList(x => x.UserID == userId && x.IsPublish == false && x.StartDate == null);

                if (requests != null && requests.Count > 0)
                {
                    foreach (var item in requests)
                    {
                        item.IsPublish = true;
                        item.StartDate = DateTime.Now;
                        item.FinishDate = DateTime.Now.AddDays(2);
                        _uow.RequestsRepository.Update(item);
                        _uow.SaveChanges();

                        var serviceList = _uow.ServiceRepository.GetList(x => x.IsActive == true && x.ServiceCategoryID == item.ServiceCategoryID);

                        foreach (var service in serviceList)
                        {
                            var request = _uow.ServiceRequestRelationRepository.Add(new ServiceRequestRelation { IsActive = true, ServiceCategoryID = service.ServiceCategoryID, ServiceID = service.ID, ServiceUserID = service.UserID, ServiceRequestID = item.ID, Status = (int)ServiceRequestRelationStatus.Waiting });
                            _uow.SaveChanges();
                            string url = "/booking-view?request_id=" + request.ID;
                            string description = _lexService.GetTextValue("_new_service_booking_created", 23);
                            await _notifyService.AddNotificationSync(new NewNotificationModel { Description = description, Url = url, UserID = request.ServiceUserID });
                        }
                    }

                    result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                _exceptionManager.HandleException(ex);
            }
            return result;
        }

    }
}
