﻿using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ConCreate
{
    public class NotificationRepository : EFEntityRepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(ServiceBuilderContext dbContext) : base(dbContext)
        {
        }
    }
}
