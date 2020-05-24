using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CRS.App_Level;
using CRS.Models;
using CRS.Models.DTOs;
using IT.IRepository;

using Permission = CRS.Models.RolePermission;

namespace CRS.Services
{
    public class PermissionsService:BaseService
    {
        internal PermissionsService(IUnitOfWork uow, int accessCode)
            : base(uow, accessCode)
        {
        }

        internal IList<IRolePermission> GetUsersAccessibleItems(int roleCode)
        {
            List<IRolePermission> subset = new List<IRolePermission>();
            var all = base.FindAll<Permission>();
            
            subset.AddRange(all.Where(c=>c.AccessCode == roleCode).ToList());

            return subset;
        }

        internal IList<IRolePermission> GetUsersAccessibleItemsOnPage(int roleCode, int pageId)
        {
            IList<IRolePermission> usersItems = GetUsersAccessibleItems(roleCode);
            IList<IRolePermission> subset = usersItems.Where(c => c.WidgetInventory.PageId == pageId).ToList();

            return subset;
        }
    }
}
