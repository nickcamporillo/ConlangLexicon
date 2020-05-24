using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CRS.Models;
using CRS.Models.DTOs;
using IT.IRepository;

namespace CRS.Services
{
    public class ActivityLogsService : BaseService
    {
        public ActivityLogsService(IUnitOfWork uow)
            :base(uow)
        {
        }

        public IList<ActivityLog> GetAllLogs()
        {
            return base.FindAll<ActivityLog>();
        }

        public IList<ActivityLog> FindLogItemByActionType(int actionCode)
        {
            return base.FindItems<ActivityLog>(a => a.ActionType == actionCode);
        }

        public void AddLog(ActivityLog logItem)
        {
            base.Add<ActivityLog>(logItem);
        }

        public void Save()
        {
            base.SaveAndCommit();
        }
    }
}
