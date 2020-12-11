using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Views;
using ViewModel.Views.Notification;

namespace Business.Service.Infrastructure
{
    public interface INotificationService
    {
        CommonResult GetUnReadNotifications(long user_id);
        CommonResult GetAllNotification(NotificationSearchModel search);
        CommonResult AddNotification(NewNotificationModel notify);
        Task AddNotificationSync(NewNotificationModel notify);
        Task<CommonResult> ReadNotificationsAsync(long userId);
    }
}
