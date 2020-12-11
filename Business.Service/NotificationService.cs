using Business.Service.Infrastructure;
using Repository.Base;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Views;
using ViewModel.Views.Notification;

namespace Business.Service
{
    public class NotificationService : INotificationService
    {
        INotificationRepository _notifyRepo;
        IQuerableRepository _queryRepo;
        public NotificationService(INotificationRepository notificationRepository, IQuerableRepository querableRepository)
        {
            _notifyRepo = notificationRepository;
            _queryRepo = querableRepository;
        }
        public CommonResult AddNotification(NewNotificationModel notify)
        {
            CommonResult result = new CommonResult();
            try
            {
                var notfiyDb = _notifyRepo.Add(new DataModel.BaseEntities.Notification { Description = notify.Description, IsRead = false, IsActive = true, Url = notify.Url, UserID = notify.UserID, });

                result.IsSuccess = true;
                result.Data = notfiyDb.ID;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Data = ex.Message;
                return result;
            }

        }
        public Task AddNotificationSync(NewNotificationModel notify)
        {
            return _notifyRepo.AddASync(new DataModel.BaseEntities.Notification { Description = notify.Description, IsRead = false, IsActive = true, Url = notify.Url, UserID = notify.UserID, });
        }
        public CommonResult GetAllNotification(NotificationSearchModel search)
        {
            CommonResult result = new CommonResult();

            string query = @"select ID, Description, IsRead, Url ,CreateDate from notifications where UserID = @CurrentUserId ";

            query += " LIMIT  " + search.PageIndex * search.TakeRow + "," + search.TakeRow;

            var list = _queryRepo.GetList<NotificationListModel>(query, search);

            result.Data = list;

            string queryCount = @"select Count(ID) from notifications where UserID = @CurrentUserId ";

            var counter = _queryRepo.GetSingle<long>(queryCount, search);
            result.DataCount = counter;

            return result;

        }

        public async Task<CommonResult> ReadNotificationsAsync(long userId)
        {
            CommonResult result = new CommonResult();
            string query = "update notifications set IsRead = 1 where UserID = " + userId.ToString() + " and IsRead = 0";
            var value = await _queryRepo.ExecuteQueryASync(query,null);
            result.Data = value;
            result.IsSuccess = true;
            return result;

        }

        public CommonResult GetUnReadNotifications(long user_id)
        {
            CommonResult result = new CommonResult();

            NotificationSearchModel search = new NotificationSearchModel();

            search.CurrentUserId = user_id;
            search.PageIndex = 0;
            search.TakeRow = 20;
            string query = @"select ID, Description, IsRead, Url , CreateDate from notifications where UserID = @CurrentUserId and IsRead = 0 ";

            query += " LIMIT  " + search.PageIndex * search.TakeRow + "," + search.TakeRow;

            var list = _queryRepo.GetList<NotificationListModel>(query, search);

            result.Data = list;

            string queryCount = @"select Count(ID) from notifications where  UserID = @CurrentUserId and IsRead = 0";

            var counter = _queryRepo.GetSingle<long>(queryCount, search);
            result.DataCount = counter;

            return result;
        }
    }
}
