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

namespace Business.Service
{
    public class RequestService : IRequestService
    {
        IServiceRequestsRepository _requestRepo;
        IServiceRequestPropertyRepository _propertyRepo;
        IQuerableRepository _queryRepo;
        ILexiconService _lexService;
        public RequestService(IServiceRequestsRepository serviceRequests, IServiceRequestPropertyRepository serviceRequestPropertyRepository, IQuerableRepository querableRepository, ILexiconService lexiconService)
        {
            _requestRepo = serviceRequests;
            _propertyRepo = serviceRequestPropertyRepository;
            _queryRepo = querableRepository;
            _lexService = lexiconService;
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
        public AddOrEditRequestModel GetBookingDetailForEdit(long request_id)
        {
            var search = new RequestSearchModel { p0 = request_id };

            string query = @" select 
                                    *
                                     from servicerequests sr where sr.ID = @p0";

            var detail = _queryRepo.GetSingle<AddOrEditRequestModel>(query, search);

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
                                    ci.Name  as CityName
                                     from servicerequests sr
                                    inner join servicecategories sc on sc.Id = sr.ServiceCategoryID
                                    inner join users u on u.Id = sr.UserID 
                                    inner join countries co on co.ID = sr.CountryID
                                    inner join cities ci on ci.ID = sr.CityID
                                    inner join users u on u.Id = sr.UserID where sr.IsActive = 1 and u.ID = @UserID";

            if (search.ServiceCategoryID.HasValue)
                query += "  and sr.ServiceCategoryID = @ServiceCategoryID";

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
