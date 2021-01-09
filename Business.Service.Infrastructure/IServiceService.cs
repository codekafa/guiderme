using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Service;

namespace Business.Service.Infrastructure
{
    public interface IServiceService
    {
        CommonResult GetServiceList(ServiceSearchModel search);

        ServiceDetailModel GetServiceDetail(long service_id);
        CommonResult AddOrEditService(AddOrEditServiceModel request);

        AddOrEditServiceModel GetServiceDetailForEdit(long service_id);
        CommonResult RemoveService(long service_id, long user_id);

        CommonResult AddRelationsAndNotificationsRequestByServices(long serviceCategoryID, long request_id);
    }
}
