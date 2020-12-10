using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Request;
using ViewModel.Views.Service;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class RequestService : IRequestService
    {
        IServiceRequestsRepository _requestRepo;
        IServiceRequestPropertyRepository _propertyRepo;
        IQuerableRepository _queryRepo;
        ILexiconService _lexService;
        IUserRepository _userRepo;
        public RequestService(IServiceRequestsRepository serviceRequests, IServiceRequestPropertyRepository serviceRequestPropertyRepository, IQuerableRepository querableRepository, ILexiconService lexiconService, IUserRepository userRepo)
        {
            _requestRepo = serviceRequests;
            _propertyRepo = serviceRequestPropertyRepository;
            _queryRepo = querableRepository;
            _lexService = lexiconService;
            _userRepo = userRepo;
        }
        public CommonResult AddNewRequest(NewRequestModel request)
        {
            CommonResult result = new CommonResult();


            try
            {
                ServiceRequest sReq = new ServiceRequest();

                sReq.CityID = request.CityId;
                sReq.CountryID = request.CountryId;
                sReq.IsPublish = request.IsPublish;
                sReq.ServiceCategoryID = request.CategoryId;
                sReq.Description = request.Description;
                if (request.IsPublish)
                    sReq.StartDate = DateTime.Now;

                sReq.UserID = request.UserId;
                sReq.FinishDate = null;
                sReq = _requestRepo.Add(sReq);

                if (request.Properties != null)
                {
                    foreach (var item in request.Properties)
                    {
                        ServiceRequestProperty prop = new ServiceRequestProperty();
                        prop.IsActive = true;
                        prop.ServiceCategoryPropertyID = item.Id;
                        prop.ServiceRequestID = sReq.ID;
                        prop.UserID = sReq.UserID;
                        prop.Value = item.Value;
                        _propertyRepo.Add(prop);
                    }
                }

               

                var user = _userRepo.Get(x => x.ID == sReq.UserID);

                if (user.UserType == (int)UserTypes.Servicer)
                {
                    user.UserType = (int)UserTypes.ServicerEndEmployer;
                    _userRepo.Update(user);
                }

                result.IsSuccess = true;
                result.Message = _lexService.GetAlertSring("added_new_booking_successfuly", null);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;

        }
        public CommonResult AddOrEditRequest(AddOrEditRequestModel request)
        {
            throw new NotImplementedException();
        }
        public RequestDetailModel GetBookingDetailForView(long request_id)
        {
            var search = new RequestSearchModel { p0 = request_id };

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
                                     from servicerequests sr
                                    inner join servicecategories sc on sc.Id = sr.ServiceCategoryID
                                    inner join users u on u.Id = sr.UserID 
                                    inner join countries co on co.ID = sr.CountryID
                                    inner join cities ci on ci.ID = sr.CityID 
                                    where sr.ID = @p0";

            var detail = _queryRepo.GetSingle<RequestDetailModel>(query, search);

            if (detail == null )
                return detail;

            detail.Properties = new List<RequestPorpertyModel>();

            string queryProps = @"SELECT srp.ID, srp.Value, scp.name FROM servicebuilder.servicerequestproperties srp
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
                                    (select COUNT(rb.ID) from RequestBids rb where rb.ServiceRequestID = sr.ID) as BidCount
                                     from servicerequests sr
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
                                     from servicerequests sr
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
                                     from servicerequests sr
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
                                     from servicerequests sr
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
                var exist = _requestRepo.Get(x => x.ID == request_id && x.UserID == user_id);

                if (exist == null)
                {
                    result.IsSuccess = false;
                    result.Message = _lexService.GetAlertSring("_booking_not_found", null);
                    return result;
                }

                exist.IsActive = false;
                _requestRepo.Update(exist);

                result.IsSuccess = true;
                result.Message = _lexService.GetAlertSring("_booking_removed_successfuly", null);
                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }


    }
}
