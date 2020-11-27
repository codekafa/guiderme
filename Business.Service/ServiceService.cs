using Business.Service.Infrastructure;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Service;

namespace Business.Service
{
    public class ServiceService : IServiceService
    {

        IServiceRepository _serviceRepo;
        IServicePhotoRepository _photoRepo;
        IQuerableRepository _queryRepo;
        public ServiceService(IServiceRepository serviceRepo, IServicePhotoRepository photoRepo, IQuerableRepository queryRepo)
        {
            _serviceRepo = serviceRepo;
            _photoRepo = photoRepo;
            _queryRepo = queryRepo;
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

    }
}
