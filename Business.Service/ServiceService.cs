using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Notification;
using ViewModel.Views.Service;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class ServiceService : IServiceService
    {

        IQuerableRepository _queryRepo;
        ILexiconService _lexService;
        IFileService _fileService;
        IUnitOfWork _uow;
        IExceptionManager _exceptionManager;
        INotificationService _notifyService;
        public ServiceService(IQuerableRepository queryRepo, ILexiconService lexiconService, IFileService fileService , IUnitOfWork unitOfWork,IExceptionManager exceptionManager, INotificationService notificationService)
        {
            _queryRepo = queryRepo;
            _lexService = lexiconService;
            _fileService = fileService;
            _uow = unitOfWork;
            _exceptionManager = exceptionManager;
            _notifyService = notificationService;
        }
        public CommonResult AddOrEditService(AddOrEditServiceModel request)
        {
            CommonResult result = new CommonResult();
            try
            {
                result = ValidateServiceModel(request);

                if (!result.IsSuccess)
                    return result;


                DataModel.BaseEntities.Service serviceProfile = new DataModel.BaseEntities.Service();

                if (request.ID > 0)
                    serviceProfile = _uow.ServiceRepository.Get(x => x.ID == request.ID);

                serviceProfile.CityID = request.CityID;
                serviceProfile.CountryID = request.CountryID;
                serviceProfile.Description = request.Description;
                serviceProfile.Name = request.Name;
                serviceProfile.ServiceCategoryID = request.ServiceCategoryID;
                serviceProfile.ServiceStartYear = request.ServiceStartYear;
                serviceProfile.UserID = request.UserID;

                if (request.MainPhoto != null)
                {
                    var photoResult = _fileService.SaveImage(request.MainPhoto, FileTypes.ServiceFiles);

                    if (photoResult.IsSuccess)
                        serviceProfile.Photo = photoResult.Data.ToString();
                }

                if (serviceProfile.ID > 0)
                {
                    serviceProfile = _uow.ServiceRepository.Update(serviceProfile);
                }
                else
                {
                    serviceProfile = _uow.ServiceRepository.Add(serviceProfile);

                    var user = _uow.UserRepository.Get(x => x.ID == serviceProfile.UserID);

                    if (user.UserType == (int)UserTypes.Customer)
                    {
                        user.UserType = (int)UserTypes.ServicerEndEmployer;
                        _uow.UserRepository.Update(user);
                    }
                }

                _uow.SaveChanges();

                if (request.ServicePhotos != null)
                {
                    foreach (var item in request.ServicePhotos)
                    {
                        var photoResult = _fileService.SaveImage(item, FileTypes.ServiceFiles);
                        if (photoResult.IsSuccess)
                        {
                            string urlPhoto = photoResult.Data.ToString();
                            Uri uri = new Uri(urlPhoto);
                            string photoName = System.IO.Path.GetFileName(uri.LocalPath);
                            _uow.ServicePhotoRepository.Add(new DataModel.BaseEntities.ServicePhoto { IsActive = true, PhotoName = photoName, PhotoUrl = urlPhoto, ServiceID = serviceProfile.ID });
                        }
                    }
                    _uow.SaveChanges();
                }

                result.IsSuccess = true;
                result.Message = _lexService.GetAlertSring("_service_update_has_been_successfuly", null);
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
        public CommonResult ValidateServiceModel(AddOrEditServiceModel request)
        {
            CommonResult result = new CommonResult();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                result.Message = _lexService.GetTextValue("_service_name_is_required", 99);
                result.IsSuccess = false;
                return result;
            }

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                result.Message = _lexService.GetTextValue("_description_is_required", 99);
                result.IsSuccess = false;
                return result;
            }

            if (request.CountryID <= 0)
            {
                result.Message = _lexService.GetTextValue("_country_is_required", 99);
                result.IsSuccess = false;
                return result;
            }

            if (request.CityID <= 0)
            {
                result.Message = _lexService.GetTextValue("_city_is_required", 99);
                result.IsSuccess = false;
                return result;
            }

            if (request.ServiceCategoryID <= 0)
            {
                result.Message = _lexService.GetTextValue("_service_category_is_required", 99);
                result.IsSuccess = false;
                return result;
            }

            if (string.IsNullOrWhiteSpace(request.Photo) && request.MainPhoto == null)
            {
                result.Message = _lexService.GetTextValue("_main_photo_is_required", 99);
                result.IsSuccess = false;
                return result;
            }

            if (request.ID > 0)
            {
                var exist_service = _uow.ServiceRepository.Get(x => x.ServiceCategoryID == request.ServiceCategoryID && x.UserID == request.UserID && x.ID != request.ID && x.IsActive == true);

                if (exist_service != null)
                {
                    result.Message = _lexService.GetTextValue("_this_service_alreay_exist_your_services", 99);
                    result.IsSuccess = false;
                    return result;
                }

            }
            else
            {
                var exist_service = _uow.ServiceRepository.Get(x => x.ServiceCategoryID == request.ServiceCategoryID && x.UserID == request.UserID && x.IsActive == true);

                if (exist_service != null)
                {
                    result.Message = _lexService.GetTextValue("_this_service_alreay_exist_your_services", 99);
                    result.IsSuccess = false;
                    return result;
                }
            }



            result.IsSuccess = true;
            return result;

        }
        public ServiceDetailModel GetServiceDetail(long service_id)
        {
            var search = new ServiceSearchModel { ServiceID = service_id };


            string query = @"select 
                                    se.ID,
                                    se.Name,
                                    us.Email,
                                    sc.Name as ServiceCategroy,
                                    co.Name as Country,
                                    ci.Name as City,
                                    se.ServiceStartYear,
                                    se.CreateDate,
                                    se.Longitude,
                                    se.Latitude
                                     from services se 
                                    INNER JOIN servicecategories sc on sc.ID = se.ServiceCategoryID
                                    INNER JOIN countries co on co.ID = se.CountryID
                                    INNER JOIN cities ci on ci.ID = se.CityID
                                    INNER JOIN users us on us.ID = se.UserID
                                    WHERE se.IsACtive = 1 and se.ID = @ServiceID";

            var detail = _queryRepo.GetSingle<ServiceDetailModel>(query, search);

            return detail;
        }
        public CommonResult GetServiceList(ServiceSearchModel search)
        {

            CommonResult result = new CommonResult();

            string query = @"select 
                                    se.ID,
                                    se.Name,
                                    us.Email,
                                    sc.Name as ServiceCategory,
                                    co.Name as Country,
                                    ci.Name as City,
                                    se.ServiceStartYear,
                                    se.CreateDate,
                                    se.Longitude,
                                    se.Latitude,
                                    se.Photo,
                                    us.Phone,
                                    us.ProfilePhoto as UserPhoto
                                    from services se 
                                    INNER JOIN servicecategories sc on sc.ID = se.ServiceCategoryID
                                    INNER JOIN countries co on co.ID = se.CountryID
                                    INNER JOIN cities ci on ci.ID = se.CityID
                                    INNER JOIN users us on us.ID = se.UserID
                                    WHERE se.IsACtive = 1 and us.IsActive = 1";


            if (!string.IsNullOrWhiteSpace(search.CategoryUri))
                query += " and sc.Url = @CategoryUri";

            if (search.ServiceCategoryID.HasValue)
                query += "  and se.ServiceCategoryID = @ServiceCategoryID";

            if (search.CountryID.HasValue)
                query += " and se.CountryID = @CountryID";

            if (search.CityID.HasValue)
                query += " and  se.CityID = @CityID";

            if (search.ServiceID.HasValue)
                query += "  and se.ID = @ServiceID";

            if (search.UserID.HasValue)
                query += " and  se.UserID = @UserID";


            query += " LIMIT  " + search.PageIndex * search.TakeRow + "," + search.TakeRow;

            var list = _queryRepo.GetList<ServiceListModel>(query, search);

            string queryCount = @"select 
                                    COUNT(se.ID)
                                     from services se 
                                    INNER JOIN servicecategories sc on sc.ID = se.ServiceCategoryID
                                    INNER JOIN countries co on co.ID = se.CountryID
                                    INNER JOIN cities ci on ci.ID = se.CityID
                                    INNER JOIN users us on us.ID = se.UserID
                                    WHERE se.IsACtive = 1";

            if (!string.IsNullOrWhiteSpace(search.CategoryUri))
                queryCount += " and sc.Url = @CategoryUri";

            if (search.ServiceCategoryID.HasValue)
                queryCount += "  and se.ServiceCategoryID = @ServiceCategoryID";

            if (search.CountryID.HasValue)
                queryCount += " and se.CountryID = @CountryID";

            if (search.CityID.HasValue)
                queryCount += " and  se.CityID = @CityID";

            if (search.ServiceID.HasValue)
                queryCount += "  and se.ID = @ServiceID";

            if (search.UserID.HasValue)
                queryCount += " and  se.UserID = @UserID";


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
        public AddOrEditServiceModel GetServiceDetailForEdit(long service_id)
        {
            string query = @"select 
                                   se.*
                                     from services se 
                                    WHERE se.IsActive = 1 and se.ID = @p0";
            var detail = _queryRepo.GetSingle<AddOrEditServiceModel>(query, new BaseParamModel { p0 = service_id });

            if (detail != null)
            {
                detail.ServiceImages = new List<string>();

                var photos = _uow.ServicePhotoRepository.GetList(x => x.ServiceID == service_id);

                foreach (var item in photos)
                {
                    detail.ServiceImages.Add(item.PhotoUrl);
                }
            }


            return detail;
        }
        public CommonResult RemoveService(long service_id, long user_id)
        {
            CommonResult result = new CommonResult();


            try
            {
                var exist = _uow.ServiceRepository.Get(x => x.ID == service_id && x.UserID == user_id);


                if (exist == null)
                {
                    result.IsSuccess = false;
                    result.Message = _lexService.GetAlertSring("_service_not_found", null);
                    return result;
                }

                exist.IsActive = false;
                _uow.ServiceRepository.Update(exist);
                _uow.SaveChanges();
                result.IsSuccess = true;
                result.Message = _lexService.GetAlertSring("_service_removed_successfuly", null);
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
        public CommonResult AddRelationsAndNotificationsRequestByServices(long serviceCategoryID, long request_id)
        {
            CommonResult result = new CommonResult();
            var serviceList = _uow.ServiceRepository.GetList(x => x.IsActive == true && x.ServiceCategoryID == serviceCategoryID);

            foreach (var service in serviceList)
            {
                var request = _uow.ServiceRequestRelationRepository.Add(new ServiceRequestRelation { IsActive = true, ServiceCategoryID = service.ServiceCategoryID, ServiceID = service.ID, ServiceUserID = service.UserID, ServiceRequestID = request_id, Status = (int)ServiceRequestRelationStatus.Waiting });
                _uow.SaveChanges();
                string url = "/booking-view?request_id=" + request.ID;
                string description = _lexService.GetTextValue("_new_service_booking_created", 23);
                _notifyService.AddNotification(new NewNotificationModel { Description = description, Url = url, UserID = request.ServiceUserID });
            }

            result.IsSuccess = true;
            return result;

        }
    }
}
